using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionContainer : MonoBehaviour
{
    public int cellIndex;

    [HideInInspector] public Team winnerTeam;

    [SerializeField] private Image winnerTeamIndicator;
    [SerializeField] private Text topic_Text;
    [SerializeField] private Button button;

    private QuestionSO question;

    private void Start()
    {
        //winnerTeamIndicator.color = Color.gray;

        button.onClick.AddListener(() =>
        {
            GameManager.Instance.questionUI.SetQuestion(question);
            GameManager.Instance.activeQuestionContainer = this;
        });
    }

    public void SetButtonListener(System.Action action)
    {
        button.onClick.AddListener(action.Invoke);
    }

    public void SetQuestion(QuestionSO question)
    {
        this.question = question;
    }

    public void SetTopic(QuestionSO.Topics topic)
    {
        topic_Text.text = ArabicFixerTool.FixLine(GameManager.Instance.topicStrings[topic]);
    }

    public void SetIncorrect()
    {
        button.interactable = false;
        //winnerTeamIndicator.color = Color.black;
    }

    public void SetWinnerTeam(Team winnerTeam)
    {
        button.interactable = false;
        this.winnerTeam = winnerTeam;
        winnerTeamIndicator.color = winnerTeam.teamColor;
    }
}