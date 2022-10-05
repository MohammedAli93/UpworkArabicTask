using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionUI : MonoBehaviour
{
    //=============================
    //========== UI elements =============

    [SerializeField] GameSettingsSO gameSettingsSO;
    [SerializeField] private GameObject teamSelection_Panel;
    [SerializeField] private GameObject answers_Panel;
    [SerializeField] private Button enableAnswers_BTN;
    [SerializeField] private Text question_TXT;
    [SerializeField] private Text topic_TXT;
    [SerializeField] private Text timer_TXT; //زمن ظهور الإجابة
    [SerializeField] private List<Button> answersButtons;

    int answerShowTime;
    int answerStayTime;

    //20 >> زمن بقاء السؤال

    //=============================
    //=========== Timer ============

    private IEnumerator timerCoroutine;

    //=============================

    private void Awake()
    {
        enableAnswers_BTN.onClick.AddListener(ShowAnswersPanel);
        timer_TXT.text = gameSettingsSO.answerShowTime.ToString();
        Debug.Log(timer_TXT.text);
        answerShowTime = gameSettingsSO.answerShowTime;

        answerStayTime = gameSettingsSO.answerStayTime;
        Debug.Log(answerShowTime);
        Debug.Log(answerStayTime);
    }
    private void Start()
    {
     
    }
    public void SetQuestion(QuestionSO question)
    {
        gameObject.SetActive(true);
        teamSelection_Panel.SetActive(true);
        answers_Panel.SetActive(false);
        enableAnswers_BTN.gameObject.SetActive(false);


        question_TXT.text = ArabicFixerTool.FixLine(question.QuestionString);
        topic_TXT.text = ArabicFixerTool.FixLine(question.Topic.ToString());


        int correctAnswerButtonIndex = Random.Range(0, answersButtons.Count);
        answersButtons[correctAnswerButtonIndex].GetComponentInChildren<Text>().text = ArabicFixerTool.FixLine(question.CorrectAnswer);
        answersButtons[correctAnswerButtonIndex].onClick.RemoveAllListeners();
        answersButtons[correctAnswerButtonIndex].onClick.AddListener(OnCorrectAnswer);


        List<int> reservedAnswerButtonsIndexes = new List<int>();
        reservedAnswerButtonsIndexes.Add(correctAnswerButtonIndex);


        for (int i = 0; i < question.WrongAnswers.Count; i++)
        {

            int x = 0;
            do
            {

                x = Random.Range(0, answersButtons.Count);

            }
            while (reservedAnswerButtonsIndexes.Contains(x));


            reservedAnswerButtonsIndexes.Add(x);
            answersButtons[x].GetComponentInChildren<Text>().text = ArabicFixerTool.FixLine(question.WrongAnswers[i]);
            answersButtons[x].onClick.RemoveAllListeners();
            answersButtons[x].onClick.AddListener(OnWrongAnswer);

        }

        StartTimer(answerShowTime, () =>
        {
            ShowAnswersPanel();
            StartTimer(answerStayTime, GameManager.Instance.ShowTopicSelection);
        });
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        StopTimer();
        gameObject.SetActive(false);
    }

    public void ShowAnswersPanel()
    {
        teamSelection_Panel.SetActive(false);
        enableAnswers_BTN.gameObject.SetActive(false);

        answers_Panel.SetActive(true);

        StopTimer();
    }

    public void ShowTeamSelectionPanel()
    {
        enableAnswers_BTN.gameObject.SetActive(false);
        answers_Panel.SetActive(false);

        teamSelection_Panel.SetActive(true);
    }

    public void ShowEnableAnswersButton()
    {
        answers_Panel.SetActive(false);
        teamSelection_Panel.SetActive(false);

        enableAnswers_BTN.gameObject.SetActive(true);
    }

    private void OnCorrectAnswer()
    {
        Debug.Log("Correct!");

        StopTimer();
        GameManager.Instance.OnCorrectAnswer();
    }

    private void OnWrongAnswer()
    {
        Debug.Log("Wrong!");

        StopTimer();
        GameManager.Instance.OnWrongAnswer();
    }

    public void StartTimer(float time, System.Action timeUpAction)
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        timerCoroutine = TimerCoroutine(time, timeUpAction);
        StartCoroutine(timerCoroutine);
    }

    public void StopTimer()
    {
        timer_TXT.text = "";

        StopCoroutine(timerCoroutine);
    }

    private IEnumerator TimerCoroutine(float time, System.Action timeUpAction)
    {
        float elapsedTime = time;
        while (elapsedTime > 0)
        {
            timer_TXT.text = System.Convert.ToInt16(elapsedTime).ToString();
            elapsedTime -= Time.deltaTime;
            yield return null;
        }

        if (timeUpAction != null)
            timeUpAction.Invoke();

        Debug.Log("Time Up!");
    }
}