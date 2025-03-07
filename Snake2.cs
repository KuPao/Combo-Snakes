using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Snake2 : MonoBehaviour
{
    
    // Current movement direction
    // (by default it move to right)
    Vector2 dir /*= 3*Vector2.right*/;
    List<Transform> tail = new List<Transform>();
    // Did the snake eat something?
    bool ate = false;
    public scores score;
    // Tail Prefab
    public GameObject tailPrefab;
    // Food Prefab
    public GameObject foodPrefab;
    private BlockSpawn Blockinf;
    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
   // public string SceneName;
    public GameObject[] resets;
    public GameObject UIscore;
    public float start_time = 0;

    public Renderer rend;
    private float size;
    private float time = 0;
    private float lastTime = 0;
    public int combo = 0;
    public Text ComboText;

    private float range = 0.3f;
    private float last_input = 0;

    private static int count = 0;
    void Start()
    {
        Time.timeScale = 1f;
        rend = GetComponent<Renderer>();
        size = rend.bounds.size.x;
        start_time = Time.time;
        //InvokeRepeating("TIME", 0.0f, 0.001f);
        // Move the snake every 10ms;
        InvokeRepeating("Move", 0.005f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - last_input > 0.175f || last_input == 0) {
            if (Input.GetKey(KeyCode.D) && dir != -size * Vector2.right && dir != size * Vector2.right) {
                float current_time = Time.time;
                last_input = current_time;
                if ((current_time - start_time) % 1.0 <= 0.5 + range && (current_time - start_time) % 1.0 >= 0.5 - range) {
                    Debug.Log("On tempo");
                    //Debug.Log(current_time);
                    //Debug.Log(lastTime);
                    Debug.Log(current_time - lastTime);
                    if ((current_time - lastTime <= 0.5 + range && current_time - lastTime >= 0.5 - range) || combo == 0) {
                        combo++;
                        lastTime = current_time;
                    }
                }
                else
                    combo = 0;
                Console.WriteLine(lastTime);
                ComboText.text = "combo " + combo + "";
                dir = size * Vector2.right;
            }

            else if (Input.GetKey(KeyCode.S) && dir != -size * Vector2.up && dir != size * Vector2.up) {
                float current_time = Time.time;
                last_input = current_time;
                if ((current_time - start_time) % 1.0 <= 0.5 + range && (current_time - start_time) % 1.0 >= 0.5 - range) {
                    Debug.Log("On tempo");
                    //Debug.Log(current_time);
                    //Debug.Log(lastTime);
                    Debug.Log(current_time - lastTime);
                   if ((current_time - lastTime <= 0.5 + range && current_time - lastTime >= 0.5 - range) || combo == 0) {
                        combo++;
                        lastTime = current_time;
                    }
                }
                else
                    combo = 0;
                Console.WriteLine(lastTime);
                ComboText.text = "combo " + combo + "";
                dir = -size * Vector2.up;    // '-up' means 'down'
            }

            else if (Input.GetKey(KeyCode.A) && dir != -size * Vector2.right && dir != size * Vector2.right) {
                float current_time = Time.time;
                last_input = current_time;
                if ((current_time - start_time) % 1.0 <= 0.5 + range && (current_time - start_time) % 1.0 >= 0.5 - range) {
                    Debug.Log("On tempo");
                    //Debug.Log(current_time);
                    //Debug.Log(lastTime);
                    Debug.Log(current_time - lastTime);

                   if ((current_time - lastTime <= 0.5 + range && current_time - lastTime >= 0.5 - range) || combo == 0) {
                        combo++;
                        lastTime = current_time;
                    }
                }
                else
                    combo = 0;
                Console.WriteLine(lastTime);
                ComboText.text = "combo " + combo + "";
                dir = -size * Vector2.right; // '-right' means 'left'
            }

            else if (Input.GetKey(KeyCode.W) && dir != -size * Vector2.up && dir != size * Vector2.up) {
                float current_time = Time.time;
                last_input = current_time;
                if ((current_time - start_time) % 1.0 <= 0.5 + range && (current_time - start_time) % 1.0 >= 0.5 - range) {
                    Debug.Log("On tempo");
                    //Debug.Log(current_time);
                    //Debug.Log(lastTime);
                    Debug.Log(current_time - lastTime);

                   if ((current_time - lastTime <= 0.5 + range && current_time - lastTime >= 0.5 - range) || combo == 0) {
                        combo++;
                        lastTime = current_time;
                    }
                }
                else
                    combo = 0;
                Console.WriteLine(lastTime);
                ComboText.text = "combo " + combo + "";
                dir = size * Vector2.up;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        // Food?
        if (coll.name.StartsWith("FoodPrefab"))
        {
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(coll.gameObject);
            // x position between left & right border
            int x = (int)UnityEngine.Random.Range(borderLeft.position.x + 10,
                                      borderRight.position.x - 10);

            // y position between top & bottom border
            int y = (int)UnityEngine.Random.Range(borderBottom.position.y + 10,
                                      borderTop.position.y - 10);

            // Instantiate the food at (x, y)
            Instantiate(foodPrefab,
                        new Vector2(x, y),
                        Quaternion.identity); // default rotation
        }
        else if (coll.tag == "Prediction")
        {
        }
        else if (coll.tag == "Block")
        {

            resets = GameObject.FindGameObjectsWithTag("Prefab");
            foreach (GameObject reset_ in resets)
            {
                Destroy(reset_.GetComponent<Rigidbody2D>());
                Destroy(reset_.gameObject);
            }
            tail = new List<Transform>();
            score.SubScore();
            count =0;

        }
        else if (coll.tag == "cancel")
        {
            score.AddCancel();
            Destroy(coll.GetComponent<Rigidbody2D>());
            Destroy(coll.gameObject);
           
        }
        else if (coll.tag == "board")
        {
            // ToDo 'You lose' screen
            //SceneManager.LoadScene(SceneName);
            transform.position = new Vector2((borderLeft.position.x+ borderRight.position.x)/2, (borderLeft.position.y + borderRight.position.y) / 2);
            resets = GameObject.FindGameObjectsWithTag("Prefab");
            foreach (GameObject reset_ in resets)
            {
                Destroy(reset_.GetComponent<Rigidbody2D>());
                Destroy(reset_.gameObject);
            }
            tail = new List<Transform>();
            score.Zero();
            count = 0;
        }
       

    }

    void Move()
    {
        // Save current position (gap will be here)
        Vector2 v = transform.position;

        // Move head into new direction
        transform.Translate(dir);

        if (ate)
        {
            // Load Prefab into the world
            score.AddScore();
            count++;
            GameObject g = (GameObject)Instantiate(tailPrefab,
                                                  v,
                                                  Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            // Move last Tail Element to where the Head was
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void TIME()
    {
        time += 0.001f;
    }
}
