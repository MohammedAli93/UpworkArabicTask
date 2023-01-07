using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnswersClicked : MonoBehaviour
{

    public bool isActive = false;
    [SerializeField]
    private Button Answer1;

    [SerializeField]
    private Button Answer2;

    [SerializeField]
    private Button Answer3;

    Team teamname;
    [SerializeField]
    private Button Answer4;
    private void Awake()
    {

        teamname = GetComponent<Team>();
        Answer1 = Answer1.GetComponent<Button>();
        Answer2 = Answer2.GetComponent<Button>();
        Answer3 = Answer3.GetComponent<Button>();
        Answer4 = Answer4.GetComponent<Button>();
    }

    private void Update()
    {

     
            if (Input.GetKeyDown(KeyCode.A) && teamname.teamName == "Green")
            {
         
                Answer1.onClick.Invoke();
            }
           if (Input.GetKeyDown(KeyCode.Q) && teamname.teamName == "Red")
            {

             Answer1.onClick.Invoke();
            }
        if (Input.GetKeyDown(KeyCode.B))
            {
                Answer2.onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                Answer3.onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Answer4.onClick.Invoke();
            }
        


    }
}
