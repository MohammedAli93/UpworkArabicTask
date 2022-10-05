using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameSettingsSO gameSettingsSO;
    int answerStayTime;
    //=============================
    //============= Question Containers ================

    public List<QuestionContainer> questionContainers;

    [HideInInspector] public QuestionContainer activeQuestionContainer;

    //=============================
    //============= Topic Selection UI ================

    [SerializeField] private GameObject topicSelectionPanel;

    //=============================
    //============= Question UI ================

    [SerializeField] public QuestionUI questionUI;

    //=============================
    //============== Topics Buttons ===============



    //=============================
    //============== Teams ===============

    [SerializeField] private Team team1, team2;

    private Team currentSelectedTeam;
    public Team CurrentSelectedTeam
    {
        get
        {
            return currentSelectedTeam;
        }
        set
        {
            // reset indicators.
            team1.indicator.SetActive(false);
            team2.indicator.SetActive(false);

            currentSelectedTeam = value;

            if (value != null)
                currentSelectedTeam.indicator.SetActive(true);         // activate new team indicator
        }
    }

    //=============================
    //============== Topics & Questions ===============

    private List<QuestionSO> allQuestions;

    public Dictionary<QuestionSO.Topics, string> topicStrings = new Dictionary<QuestionSO.Topics, string>()
    {
        {QuestionSO.Topics.Religion, "دين" },
        {QuestionSO.Topics.Technology, "تكنولوجيا" },
        {QuestionSO.Topics.Sceince, "علوم" },
        {QuestionSO.Topics.Sports, "رياضة" },
        {QuestionSO.Topics.History, "تاريخ" },
    };

    private QuestionSO.Topics currentSelectedTopic;

    private List<QuestionSO> currentTopicQuestions;

    private QuestionSO currentSelectedQuestion;

    private List<QuestionSO> previousQuestions = new List<QuestionSO>();


    private bool currentQuestionSwapped;

    //=============================
    //============== Singleton ===============

    public static GameManager Instance;
    private void Awake() => Instance = this;

    //=============================

    private void Start()
    {
        answerStayTime = gameSettingsSO.answerStayTime;

        allQuestions = Resources.LoadAll<QuestionSO>("Questions/").ToList();


        FillQuestionContainers();



    }

    private void FillQuestionContainers()
    {
        // shuffle questions
        var shuffledQuestions = allQuestions.OrderBy(q => Random.Range(0f, 1f)).ToList();

        for (int i = 0; i < questionContainers.Count; i++)
        {
            questionContainers[i].SetTopic(shuffledQuestions[i].Topic);
            questionContainers[i].SetQuestion(shuffledQuestions[i]);
        }
    }

    // Deprecated
    public void ShowTopicSelection()
    {
        topicSelectionPanel.SetActive(true);
    }

    // Deprecated
    private void SelectTopic(QuestionSO.Topics topic)
    {
        currentSelectedTopic = topic;
        currentTopicQuestions = allQuestions.FindAll(q => q.Topic == topic);

        ShowQuestion();
    }

    public void ShowQuestion()
    {
        // if all questions have been asked.
        if (previousQuestions.FindAll(q => q.Topic == currentSelectedTopic).Count >= currentTopicQuestions.Count)
        {

            questionUI.gameObject.SetActive(false);

            Debug.Log($"all questions of <{currentSelectedTopic.ToString()}> topic have been asked!");

            return;

        }


        do
        {

            currentSelectedQuestion = currentTopicQuestions[Random.Range(0, currentTopicQuestions.Count)];

        } while (previousQuestions.Contains(currentSelectedQuestion));


        // Set UI
        questionUI.gameObject.SetActive(true);
        questionUI.ShowTeamSelectionPanel();


        previousQuestions.Add(currentSelectedQuestion);
        questionUI.SetQuestion(currentSelectedQuestion);
    }

    public void OnTeamSelection(Team team)
    {
        CurrentSelectedTeam = team;


        // Set UI
        questionUI.ShowEnableAnswersButton();


        // start 20 seconds timer.
        questionUI.StartTimer(answerStayTime,
            () =>
            {
                // show the answers, start 20 seconds timer, and swap teams if time is up.
                SwapTeams();
                questionUI.ShowAnswersPanel();
                //questionUI.StartTimer(answerStayTime, null);
                questionUI.StartTimer(answerStayTime, () =>
                {
                    questionUI.Deactivate();
                    activeQuestionContainer.SetIncorrect();
                });
            });


        Debug.Log($"Current selected team is {team.teamName}");
    }

    public void SwapTeams()
    {
        if (CurrentSelectedTeam == null)
        {
            Debug.LogError("There's no selected team!");
            return;
        }

        CurrentSelectedTeam = (CurrentSelectedTeam == team1) ? team2 : team1;
    }

    public void OnCorrectAnswer()
    {
        //CurrentSelectedTeam.IncreaseScore();
        currentQuestionSwapped = false;
        //CurrentSelectedTeam.IncreaseScore();
        questionUI.Deactivate();
        //ShowTopicSelection();
        activeQuestionContainer.SetWinnerTeam(CurrentSelectedTeam);

        team1.CheckWin();
        team2.CheckWin();

        CurrentSelectedTeam = null;
    }
    
    //public void OnWrongAnswer()
    //{
    //    // because teams can be swapped only once.
        
    //    if (!team1.swappedAnswerOnce && !team2.swappedAnswerOnce)
    //    {
    //        CurrentSelectedTeam.swappedAnswerOnce = true;
    //        SwapTeams();
    //        questionUI.StartTimer(answerStayTime, questionUI.Deactivate);

    //        return;
    //    }

    //    questionUI.StartTimer(answerStayTime, questionUI.Deactivate);
    //    questionUI.Deactivate();
    //    activeQuestionContainer.SetIncorrect();

    //    team1.indicator.SetActive(false);
    //    team2.indicator.SetActive(false);
    //}
    public void OnWrongAnswer()
    {
        // teams can be swapped once per question.
        if (!currentQuestionSwapped)
        {
            currentQuestionSwapped = true;
            SwapTeams();
            //questionUI.StartTimer(answerStayTime, questionUI.Deactivate);
            questionUI.StartTimer(answerStayTime, () =>
            {
                questionUI.Deactivate();
                activeQuestionContainer.SetIncorrect();
            });

            return;
        }

        questionUI.StartTimer(answerStayTime, questionUI.Deactivate);
        questionUI.Deactivate();
        activeQuestionContainer.SetIncorrect();

        currentQuestionSwapped = false;

        team1.indicator.SetActive(false);
        team2.indicator.SetActive(false);
    }
}