using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;
public class BG_TeamNames_Changer : MonoBehaviour
{
    [SerializeField] GameSettingsSO gameSettingsSO;
    [SerializeField] List<Sprite> BGs;
    [SerializeField] Image myImgComp;
    [SerializeField] RTLTextMeshPro greenTeamName;
    [SerializeField] RTLTextMeshPro greenfirstName;
    [SerializeField] RTLTextMeshPro greensecondName;
    [SerializeField] RTLTextMeshPro redTeamName;
    [SerializeField] RTLTextMeshPro redfirstName;
    [SerializeField] RTLTextMeshPro redsecondName;

    private void Start()
    {
        myImgComp.sprite = BGs[gameSettingsSO.bgNum -1];

        greenTeamName.text = gameSettingsSO.greenTeamName;
        Debug.Log(greenTeamName);
        greenfirstName.text = gameSettingsSO.greenfirstName;
        greensecondName.text = gameSettingsSO.greensecondName;

        redTeamName.text = gameSettingsSO.redTeamName;
        redfirstName.text = gameSettingsSO.redfirstName;
        redsecondName.text = gameSettingsSO.redsecondName;
        
    }

}
