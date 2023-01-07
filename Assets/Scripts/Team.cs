using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Team : MonoBehaviour
{
    [SerializeField] Image winUi;
    //[SerializeField] SpriteRenderer imageRef;
    [SerializeField] Text winText;
    public Color teamColor;
    [SerializeField] GameSettingsSO gameSettingsSO;
    [SerializeField] public Image winImage;
    int roundNum;
     [SerializeField] Image Texts1;
    [SerializeField] Image  Texts2;
    public float delay = .1f;
    public string NewLevel = "AhmedEmadSCene2";
    public RowOrColumn teamWinsOnMatching;

    public List<WinQuestionsIndexes> winQuestionsIndexes;

    public string teamName;
    public Image star1;
    public Image star2;
    public Image star3;
    public Image star4;

    public Image star5;
    public Image star6;
    public Image star7;
    public Image star8;

    public static Image Temp;
    public GameObject effect1;
    public GameObject effect2;
    public GameObject effect3;
    public GameObject effect4;
    public GameObject effect5;
    public GameObject effect6;
    public GameObject effect7;
    public GameObject effect8;

    public GameObject indicator;

    static bool trigger1, trigger2, trigger3, trigger4 , trigger5 , trigger6;

    static bool Final;

    public int flag;
    static bool flaged;
    [SerializeField] private Button selection_BTN;
    [SerializeField] private Text score_TXT;

    [SerializeField] private List<Neighbours> neighbours;

    public int score;
    private object questionContainer;

    private void Start()
    {
        if(trigger1)
        {
            star1.gameObject.SetActive(true);
        }
        if (trigger2)
        {
            star5.gameObject.SetActive(true);

        }
        if (trigger3)
        {
            if (!trigger1)
            {
                star1.gameObject.SetActive(true);
            }
            else
            {
                star2.gameObject.SetActive(true);
            }
            

        }
        if (trigger4)
        {
            if(!trigger2)
            {
                star5.gameObject.SetActive(true);
            }
            else
            {
                star6.gameObject.SetActive(true);
            }

        }
        if (gameSettingsSO.RoundNum == 3)
        {
            flaged = true;
            
        }
        selection_BTN.onClick.AddListener(() => GameManager.Instance.OnTeamSelection(this));
    }

    private void DontDestroyOnLoad(bool flaged)
    {
        throw new NotImplementedException();
    }

    IEnumerator LoadLevelAfterDelay()
    {
     

        yield return new WaitForSeconds(3);
        winUi.gameObject.SetActive(true);
        
        Texts1.gameObject.SetActive(false);
        Texts2.gameObject.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator LoadLevelAfterDelay3()
    {


        yield return new WaitForSeconds(3);
        winUi.gameObject.SetActive(true);

        Texts1.gameObject.SetActive(false);
        Texts2.gameObject.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    IEnumerator LoadLevelAfterDelay2()
    {


        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
                
               
                if (gameSettingsSO.RoundNum == 3)
                {
                    Debug.Log(flaged);
                    if (teamName == "Green")
                    {
                        trigger1 = true;
                        star1.gameObject.SetActive(true);
                        effect1.gameObject.SetActive(true);
                       
                        StartCoroutine(LoadLevelAfterDelay2());
                    }
                    else
                    {
                        trigger2 = true;
                        star5.gameObject.SetActive(true);
                        effect5.gameObject.SetActive(true);
                        StartCoroutine(LoadLevelAfterDelay2());

                    }
                    gameSettingsSO.RoundNum--;
                    break;
                 
                }
                else if (gameSettingsSO.RoundNum == 2)
                {
                    if (teamName == "Green")
                    {
                        if(trigger1)
                        {
                            
                            star2.gameObject.SetActive(true);
                            effect2.gameObject.SetActive(true);
                            winImage.color = Color.green;
                            StartCoroutine(LoadLevelAfterDelay());
                        }
                        else
                        {
                            trigger3 = true;
                            star1.gameObject.SetActive(true);
                            effect1.gameObject.SetActive(true);
                            StartCoroutine(LoadLevelAfterDelay2());
                        }
                        
                    }
                    else
                    {
                        if (trigger2)
                        {
                            

                            star6.gameObject.SetActive(true);
                            effect6.gameObject.SetActive(true);
                            winImage.color = Color.red;
                            StartCoroutine(LoadLevelAfterDelay3());
                        }
                        else
                        {
                            trigger4 = true;
                            star5.gameObject.SetActive(true);
                            effect5.gameObject.SetActive(true);
                            StartCoroutine(LoadLevelAfterDelay2());
                        }

                    }

                    gameSettingsSO.RoundNum--;
                    break;

                }
                if (gameSettingsSO.RoundNum == 1 && flaged)
                {
                    if (teamName == "Green")
                    {
                        if(trigger3 || trigger1)
                        {
                            star2.gameObject.SetActive(true);
                            effect2.gameObject.SetActive(true);
                            winImage.color = Color.green;
                            StartCoroutine(LoadLevelAfterDelay());
                        }
               
                    }
                    else
                    {
                        if(trigger4 || trigger2)
                        {
                            star6.gameObject.SetActive(true);
                            effect6.gameObject.SetActive(true);
                            winImage.color = Color.red;
                            StartCoroutine(LoadLevelAfterDelay3());
                        }
                 

                    }
                    break;
                }
                if (gameSettingsSO.RoundNum == 1 && !flaged)
                {
                    Debug.Log("HERE IN SOLO");
                    if (teamName == "Green")
                    {
                        star4.gameObject.SetActive(true);
                        effect4.gameObject.SetActive(true);
                        winImage.color = Color.green;
                        StartCoroutine(LoadLevelAfterDelay());
                    }
                    else
                    {
                        star8.gameObject.SetActive(true);
                        effect8.gameObject.SetActive(true);
                        winImage.color = Color.red;
                        StartCoroutine(LoadLevelAfterDelay3());

                    }

                }


                
     


                //break;
            }

                


            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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

