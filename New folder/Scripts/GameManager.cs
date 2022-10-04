using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //=============================
    //============= Topic Selection UI ================

    [SerializeField] private GameObject topicSelectionPanel;

    //=============================
    //============= Question UI ================

    [SerializeField] private QuestionUI questionUI;

    //=============================
    //============== Topics Buttons ===============

    [SerializeField] private Button historyTopic_btn;
    [SerializeField] private Button religionTopic_btn;
    [SerializeField] private Button scienceTopic_btn;
    [SerializeField] private Button sportsTopic_btn;
    [SerializeField] private Button technologyTopic_btn;

    //=============================
    //============== Teams ===============

    [SerializeField] private Team team1, team2;

    private Team currentSelectedTeam;
    private Team CurrentSelectedTeam
    {
        get
        {
            return currentSelectedTeam;
        }
        set
        {
            if (currentSelectedTeam != value)
            {
                if (currentSelectedTeam != null)
                    currentSelectedTeam.indicator.SetActive(false);        // turn off old team indicator

                currentSelectedTeam = value;

                if (value == null)
                {
                    team1.indicator.SetActive(false);
                    team2.indicator.SetActive(false);
                    return;
                }

                value.indicator.SetActive(true);         // turn on new team indicator
            }
        }
    }

    //=============================
    //============== Topics & Questions ===============

    private List<QuestionSO> allQuestions;

    private QuestionSO.Topics currentSelectedTopic;

    private List<QuestionSO> currentTopicQuestions;

    private QuestionSO currentSelectedQuestion;

    private List<QuestionSO> previousQuestions = new List<QuestionSO>();

    //=============================
    //============== Singleton ===============

    public static GameManager Instance;
    private void Awake() => Instance = this;

    //=============================

    private void Start()
    {
        allQuestions = Resources.LoadAll<QuestionSO>("Questions/").ToList();


        historyTopic_btn.onClick.AddListener(() => SelectTopic(QuestionSO.Topics.History));
        religionTopic_btn.onClick.AddListener(() => SelectTopic(QuestionSO.Topics.Religion));
        scienceTopic_btn.onClick.AddListener(() => SelectTopic(QuestionSO.Topics.Sceince));
        sportsTopic_btn.onClick.AddListener(() => SelectTopic(QuestionSO.Topics.Sports));
        technologyTopic_btn.onClick.AddListener(() => SelectTopic(QuestionSO.Topics.Technology));
    }

    public void ShowTopicSelection()
    {
        topicSelectionPanel.SetActive(true);
    }

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

    public void SetSelectedTeam(Team team)
    {
        CurrentSelectedTeam = team;


        // Timer
        questionUI.StartTimer(20,
            () =>
            {
                questionUI.ShowAnswersPanel();
                SwapTeams();
                questionUI.StartTimer(20, null);
            });


        // Set UI
        questionUI.ShowEnableAnswersButton();


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
        CurrentSelectedTeam.IncreaseScore();

        questionUI.Deactivate();
        ShowTopicSelection();

        CurrentSelectedTeam = null;
    }

    public void OnWrongAnswer()
    {
        SwapTeams();
        questionUI.StartTimer(20, ShowTopicSelection);
    }
}