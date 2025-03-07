using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class time : MonoBehaviour
{
   
    

   
    public StartGame End;
    public Text ScoreText;
    private int end = 60;
    private int start = 60;
    public string SceneName;
    public int temp = 0;
    float n = 0f;
    public GameObject P1;
    public GameObject P2;
    public GameObject Tie;
    public GameObject Scores;
    public GameObject Times;
    public GameObject Over;
    int scores1 = 0;
    int scores2 = 0;
    public Text scores;
    // Use this for initialization

    void Start()
    {
        end = 60;
        start = 60;

    }

    // Update is called once per frame
    void Update()
    {
        scores1 = PlayerPrefs.GetInt("FoodPrefab");
        scores2 = PlayerPrefs.GetInt("FoodPrefab1");
        if (end > 0)
        {
            if (Time.timeScale == 0)
            {

            }
            else
            {
                n += Time.deltaTime;
            }
            end = start - (int)n;
            ScoreText.GetComponent<Text>().text = "" + end;
            PlayerPrefs.SetInt("a", end);
        }
        if (end == 0)
        {
          
            end = start;
            temp++;
            // End.Scoress();
            Time.timeScale = 0f;

            Over.SetActive(true);
            Times.SetActive(false);
            Scores.SetActive(false);



            if (scores1 > scores2)
            {
                P1.SetActive(true);
                scores.text = "Scores: " + scores1 + "";
            }
            else if (scores1 < scores2)
            {
                P2.SetActive(true);
                scores.text = "Scores: " + scores2 + "";
            }
            else
            {
                Tie.SetActive(true);
            }
        }
    }
           
    



}
