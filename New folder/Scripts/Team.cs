using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Team : MonoBehaviour
{
    public Color teamColor;

    public string teamName;

    public GameObject indicator;

    [SerializeField] private Button selection_BTN;
    [SerializeField] private Text score_TXT;

    public int score;

    private void Start()
    {
        selection_BTN.onClick.AddListener(() => GameManager.Instance.SetSelectedTeam(this));
    }

    public void IncreaseScore()
    {
        score++;
        score_TXT.text = score + "";
    }
}