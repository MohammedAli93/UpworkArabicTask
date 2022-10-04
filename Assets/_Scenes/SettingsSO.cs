using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Settings",menuName ="Settings/new")]
public class SettingsSO : ScriptableObject
{
    public string FirstTeam;
    public string SecondTeam;
    public Sprite Background;

    public int TimeforQuestion;
    public int TimeforAnswerTostay;

    //firstteam name 
    //secondteam name 
    //number of rounds 
    //difficulty 
    //time for answer 
    //time for answer to stay
    //background
}
