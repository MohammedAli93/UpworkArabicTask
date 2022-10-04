using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG_TeamNames_Changer : MonoBehaviour
{
    [SerializeField] GameSettingsSO gameSettingsSO;
    [SerializeField] List<Sprite> BGs;
    [SerializeField] Image myImgComp;
    [SerializeField] Text greenTeamName;
    [SerializeField] Text greenfirstName;
    [SerializeField] Text greensecondName;
    [SerializeField] Text redTeamName;
    [SerializeField] Text redfirstName;
    [SerializeField] Text redsecondName;

    private void Start()
    {
        myImgComp.sprite = BGs[gameSettingsSO.bgNum - 1];

        greenTeamName.text = gameSettingsSO.greenTeamName;
        greenfirstName.text = gameSettingsSO.greenfirstName;
        greensecondName.text = gameSettingsSO.greensecondName;

        redTeamName.text = gameSettingsSO.redTeamName;
        redfirstName.text = gameSettingsSO.redfirstName;
        redsecondName.text = gameSettingsSO.redsecondName;
    }

}
