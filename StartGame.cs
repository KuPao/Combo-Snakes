using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour {
 /*   public GameObject Game;
    public GameObject Board;
    public GameObject Left;
    public GameObject Right;
    public GameObject Scores;
    public GameObject Times;
    public GameObject Over;

    public GameObject P1;
    public GameObject P2;
    public GameObject Tie;

    public GameObject ButSound;
    public AudioSource Start;
    public AudioSource Plays;

    int scores1=0;
    int scores2 = 0;
    public Text scores;*/

    // Use this for initialization
    void Awake()
    {
       
      /*  Time.timeScale = 0f;
        Plays.Stop();
        Start.enabled = true;
        if (!Start.isPlaying)
        {
            Start.Play();

        }
        Game.SetActive(true);
        Board.SetActive(false);
        Left.SetActive(false);
        Right.SetActive(false);
        Scores.SetActive(false);
        Times.SetActive(false);
        Over.SetActive(false);*/

    }
    //public Snake2 Left;
    //public Snake Right;
    void Update()
    {
       /* scores1 = PlayerPrefs.GetInt("FoodPrefab");
        scores2 = PlayerPrefs.GetInt("FoodPrefab1");*/
    }
   public void SatartGames()
    {
        SceneManager.LoadScene("snake");
        //Left.start_time = Time.time;
    }
    public void NewGame()
    {
        SceneManager.LoadScene("snake");


    }
   
    public void EndGame()
    {
      
        Application.Quit();
    }
  /*  public void Scoress()
    {
     

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
    }*/
}
   

