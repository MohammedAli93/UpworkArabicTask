using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Team : MonoBehaviour
{
    [SerializeField] Image winUi;
    [SerializeField] Text winText;
    public Color teamColor;

    public RowOrColumn teamWinsOnMatching;

    public List<WinQuestionsIndexes> winQuestionsIndexes;

    public string teamName;

    public GameObject indicator;


    [SerializeField] private Button selection_BTN;
    [SerializeField] private Text score_TXT;

    [SerializeField] private List<Neighbours> neighbours;

    public int score;

    private void Start()
    {
        selection_BTN.onClick.AddListener(() => GameManager.Instance.OnTeamSelection(this));
    }

    public void IncreaseScore()
    {
        score++;
        score_TXT.text = score + "";
    }

    public void CheckWin()
    {
        bool row_column_filled = false;

        for (int x = 0; x < winQuestionsIndexes.Count; x++)
        {
            for (int y = 0; y < winQuestionsIndexes[x].Matching_Cells_Indexes.Count; y++)
            {
                var questionContainer = GameManager.Instance.questionContainers.Find(q => q.cellIndex == winQuestionsIndexes[x].Matching_Cells_Indexes[y]);
                if (questionContainer.winnerTeam != this)
                {
                    row_column_filled = false;
                    break;
                }

                row_column_filled = true;
            }

            if (row_column_filled)
            {
                winText.text = teamName + " wins";
                winUi.gameObject.SetActive(true);
                Debug.Log("REd team wins");
            }
        }

        //foreach (var x in winQuestionsIndexes)
        //{
        //    foreach (var y in x.Matching_Cells_Indexes)
        //    {
        //        GameManager.Instance.questionContainers.
        //    }
        //}
    }


    //=========================================

    public enum RowOrColumn { Rows, Columns }


    [System.Serializable]
    public class WinQuestionsIndexes
    {
        public List<int> Matching_Cells_Indexes;
    }

    [System.Serializable]
    public class Neighbours
    {
        public List<GameObject> Matching_Cells_Indexes;
    }

}