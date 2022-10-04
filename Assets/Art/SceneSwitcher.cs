using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

public enum difficulty
{
    hard,
    medium,
    easy
}

enum roundNum
{
    one=1,
    three=3
}
enum answerShowTime
{
    first = 30,
    second=20,
    third = 15
}
enum answerStayTime
{
    first = 35,
    second = 25,
    third = 15
}
enum BG
{
    first=1,
    second,
    third,
    fourth
}

public class SceneSwitcher : MonoBehaviour
{
    public GameSettingsSO gameSettingsSO;

    [SerializeField] TextMeshProUGUI greenTeamName;
    [SerializeField] TextMeshProUGUI greenFirstName;
    [SerializeField] TextMeshProUGUI greenSecondName;

    [SerializeField] TextMeshProUGUI redTeamName;
    [SerializeField] TextMeshProUGUI redFirstName;
    [SerializeField] TextMeshProUGUI redSecondName;

    [SerializeField] List<Image> roundNumToggle;
    [SerializeField] List<Image> difficultyToggle;
    [SerializeField] List<Image> answerShowTimeToggle;
    [SerializeField] List<Image> answerStayTimeToggle;
    [SerializeField] List<Image> BGToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void playGame()
    {
        setSettingsSO();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void setSettingsSO()
    {
        #region reset before start
        gameSettingsSO.greenTeamName = "";
        gameSettingsSO.greenfirstName = "";
        gameSettingsSO.greensecondName = "";

        gameSettingsSO.redTeamName = "";
        gameSettingsSO.redfirstName = "";
        gameSettingsSO.redsecondName = "";


        gameSettingsSO.roundsNum = 0;
        gameSettingsSO.answerShowTime = 0;
        gameSettingsSO.answerStayTime = 0;
        gameSettingsSO.bgNum = 0;
        gameSettingsSO.difficulty = 0; 
        #endregion

        #region Texts
        gameSettingsSO.greenTeamName = greenTeamName.text;
        gameSettingsSO.greenfirstName = greenFirstName.text;
        gameSettingsSO.greensecondName = greenSecondName.text;

        gameSettingsSO.redTeamName = redTeamName.text;
        gameSettingsSO.redfirstName = redFirstName.text;
        gameSettingsSO.redsecondName = redSecondName.text;
        #endregion

        #region Toggles
        SetEnumValueBasedOnToggle<roundNum>(roundNumToggle, out gameSettingsSO.roundsNum);
        SetEnumValueBasedOnToggle<answerShowTime>(answerShowTimeToggle, out gameSettingsSO.answerShowTime);
        SetEnumValueBasedOnToggle<answerStayTime>(answerStayTimeToggle, out gameSettingsSO.answerStayTime);
        SetEnumValueBasedOnToggle<BG>(BGToggle, out gameSettingsSO.bgNum);

        for (int i = 0; i < difficultyToggle.Count; i++)
        {
            if (difficultyToggle[i].fillAmount > 0)
            {
                gameSettingsSO.difficulty = (((difficulty[])(Enum.GetValues(typeof(difficulty))))[i]);
            }
        }

        #endregion

        #region Testing
        //print(gameSettingsSO.greenTeamName);
        //print(gameSettingsSO.greenfirstName);
        //print(gameSettingsSO.greensecondName);

        //print(gameSettingsSO.redTeamName);
        //print(gameSettingsSO.redfirstName);
        //print(gameSettingsSO.redsecondName);

        //print(gameSettingsSO.roundsNum);
        //print(gameSettingsSO.answerShowTime);
        //print(gameSettingsSO.answerStayTime);
        //print(gameSettingsSO.bgNum);
        //print(gameSettingsSO.difficulty); 
        #endregion

    }

    private void SetEnumValueBasedOnToggle<enumType>(List<Image> toggleList, out int valueToSet)
    {
        int[] enumVals = (int[])Enum.GetValues(typeof(enumType));
        for (int i = 0; i < toggleList.Count; i++)
        {
            if (toggleList[i].fillAmount > 0)
            {
                valueToSet = enumVals[i];
                return;
            }
        }
        valueToSet = -1000;
    }
}
