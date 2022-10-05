using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new game settings",menuName ="game settings")]
public class GameSettingsSO : ScriptableObject
{
   [SerializeField] public string greenTeamName;
   [HideInInspector] public string redTeamName;

   [HideInInspector] public string greenfirstName;
   [HideInInspector] public string greensecondName;

   [HideInInspector] public string redfirstName;
   [HideInInspector] public string redsecondName;

   [HideInInspector] public int roundsNum;
   [HideInInspector] public difficulty difficulty;
   [HideInInspector] public int answerShowTime;
   [HideInInspector] public int answerStayTime;
   [HideInInspector] public int bgNum;
}
