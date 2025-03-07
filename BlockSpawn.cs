using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Block
{
    public GameObject cancel1;
    public GameObject cancel2;
    public GameObject cancel3;
    public GameObject cancel4;
    public GameObject A1;
    public GameObject B2;
    public int x;
    public int y;
    
}

public class BlockSpawn : MonoBehaviour {

    // Food Prefab
    public GameObject block;
    public GameObject block1;

    public Block A;
    List<Block> Blocks=new List<Block>();

    public GameObject cancel;
    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderMid;
    public Transform borderLeft;
    public Transform borderRight;
    public scores score;
    private int x;
    private int y;

    private static int count = 0;

    // Use this for initialization
    void Update()
    {
        foreach (Block blocks in Blocks)
        {
           
            if (blocks.cancel1 == null && blocks.cancel2 == null && blocks.cancel3 == null && blocks.cancel4 == null)
            {

                Destroy(blocks.A1.GetComponent<Rigidbody2D>());
                Destroy(blocks.A1.gameObject);
                Blocks.Remove(blocks);
                
                //count--;
            }
            
           
        }
    }
  
    void Start ()
    {        
        InvokeRepeating("Spawn", 3f, 7f);
        InvokeRepeating("Create", 4f, 7f);
        InvokeRepeating("Cancel", 5f, 7f);
    }
    
        void Cancel()
    {
        
        A.cancel1=Instantiate(cancel,
                    new Vector2(A.x+65,A.y),
                    Quaternion.identity);
        A.cancel2 = Instantiate(cancel,
                    new Vector2(A.x,A.y+65),
                    Quaternion.identity);
        A.cancel3 = Instantiate(cancel,
                    new Vector2(A.x-65,A.y),
                    Quaternion.identity);
        A.cancel4 = Instantiate(cancel,
                    new Vector2(A.x , A.y-65),
                    Quaternion.identity);
        Blocks.Add(A);
        
        count++;

    }
    // Spawn one piece of food
    void Create()
    {
       /* if (count == 5)
        {
            CancelInvoke();
        }*/
        // Instantiate the food at (x, y)
        Destroy(A.B2.GetComponent<Rigidbody2D>());
        Destroy(A.B2);
        
        A.A1=Instantiate(block,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
        
        
    }
    void Spawn()
    {
        /*if (count == 5)
        {
            CancelInvoke();
        }*/
        
        // x position between left & right border
        x = (int)Random.Range(borderLeft.position.x+100,
                                  borderMid.position.x-100);
        // y position between top & bottom border
         y = (int)Random.Range(borderBottom.position.y+100,
                                  borderTop.position.y-100);
       
        A = new Block();
        A.x = x;
        A.y = y;
        A.B2=Instantiate(block1,
                   new Vector2(x, y),
                   Quaternion.identity);

    }
}
