using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsClicked : MonoBehaviour
{

    [SerializeField]
    private Button greenTeamBut;

    [SerializeField]
    private Button redTeamBut;


    private void Awake()
    {
        greenTeamBut = greenTeamBut.GetComponent<Button>();
        redTeamBut = redTeamBut.GetComponent<Button>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) )
        {
            greenTeamBut.onClick.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) )
        {
            redTeamBut.onClick.Invoke();
        }

    }

    public void nothing()
    {

    }
}
