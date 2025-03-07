using UnityEngine;
using System.Collections;
using UnityEngine.UI; //使用UI
public class scores : MonoBehaviour
{
  //  public Text ComboText;
    public Text ScoreText; //宣告一個ScoreText的text
    public int goal = 0;
    public int Score = 0; // 宣告一整數 Score
   // public float combo = 0;
    public static scores Instance; // 設定Instance，讓其他程式能讀取GameFunction
                                   // Use this for initialization
    void Start()
    {
        Instance = this; //指定Instance這個程式
        Score = 0;
        PlayerPrefs.SetInt("FoodPrefab", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore()

    {

        Score += 1; //分數+1

        ScoreText.text = ""+Score*100 + ""; // 更改ScoreText的內容
        PlayerPrefs.SetInt("FoodPrefab", Score * 100);
    }
    public void SubScore()

    {

        Score =Score/2; //分數/2

        ScoreText.text = "" + Score * 100 + ""; // 更改ScoreText的內容
        PlayerPrefs.SetInt("FoodPrefab", Score * 100);
    }
    public void Zero()//撞牆
    {
        Score = 0;
        ScoreText.text = "" + Score * 100 + ""; // 更改ScoreText的內容
        PlayerPrefs.SetInt("FoodPrefab", Score * 100);
    }
    public void AddCancel()
    {
        Score += 2; //分數+5

        ScoreText.text = "" + Score * 100 + ""; // 更改ScoreText的內容
        PlayerPrefs.SetInt("FoodPrefab", Score * 100);
    }
   /* public void AddCombo()
    {
        combo += 1;
        ComboText.text = "" + combo + "";
    }

    public void ZeroCombo()
    {
        combo -= Time.deltaTime;
        ComboText.text = "" + combo + "";
    }*/
}
