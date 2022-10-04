using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question", order = 65)]
public class QuestionSO : ScriptableObject
{
    public Topics Topic;
    public string QuestionString;
    public string CorrectAnswer;
    public List<string> WrongAnswers;

    public enum Topics { History, Religion, Sceince, Sports, Technology }
}