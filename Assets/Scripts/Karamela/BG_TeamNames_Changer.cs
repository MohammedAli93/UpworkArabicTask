using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
using TMPro;

public class BG_TeamNames_Changer : MonoBehaviour
{
    [SerializeField] GameSettingsSO gameSettingsSO;
    //SceneSwitcher _scene;
    [SerializeField] List<Sprite> BGs;
    [SerializeField] Image myImgComp;
    [SerializeField] RTLTextMeshPro greenTeamName;
    [SerializeField] RTLTextMeshPro greenfirstName;
    [SerializeField] RTLTextMeshPro greensecondName;
    [SerializeField] RTLTextMeshPro redTeamName;
    [SerializeField] RTLTextMeshPro redfirstName;
    [SerializeField] RTLTextMeshPro redsecondName;
    [SerializeField] int roundsNum;

    private void Start()
    {
        myImgComp.sprite = BGs[gameSettingsSO.bgNum -1];
        roundsNum = gameSettingsSO.RoundNum;

       if (gameSettingsSO.greenTeamName.Length <= 1)
        {
            Debug.Log("Empty");
        }
        else
        {
            Debug.Log("NOT EMPTY");
            greenTeamName.text = gameSettingsSO.greenTeamName;

        }
        if (gameSettingsSO.greenfirstName.Length <= 1)
        {
            Debug.Log("Empty");
        }
        else
        {
            greenfirstName.text = gameSettingsSO.greenfirstName;
        }
        if (gameSettingsSO.greensecondName.Length <= 1)
        {
            Debug.Log("Empty");
        }
        else
        {
            greensecondName.text = gameSettingsSO.greensecondName;
        }
        if (gameSettingsSO.redTeamName.Length <= 1)
        {
            Debug.Log("Empty");
        }
        else
        {
            redTeamName.text = gameSettingsSO.redTeamName;
        }
        if (gameSettingsSO.redfirstName.Length <= 1)
        {
            Debug.Log("Empty");
        }
        else
        {
            redfirstName.text = gameSettingsSO.redfirstName;
        }
        if (gameSettingsSO.redsecondName.Length <= 1)
        {
            Debug.Log("Empty");
        }
        else
        {
            redsecondName.text = gameSettingsSO.redsecondName;
        }
        //Debug.Log(greenTeamName);
        //greenfirstName.text = gameSettingsSO.greenfirstName;
        //greensecondName.text = gameSettingsSO.greensecondName;

        //redTeamName.text = gameSettingsSO.redTeamName;
        //redfirstName.text = gameSettingsSO.redfirstName;
        //redsecondName.text = gameSettingsSO.redsecondName;
        
    }

}
