using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour {

    public AudioSource A;
    public AudioSource B;
    // Use this for initialization
    void Awake()
    {
        A= GetComponent<AudioSource>();
        B = GetComponent<AudioSource>();
        B.Stop();
        A.Play();
        
    }
    public void changeEnd()
    { 
        B.Play();
      
    }

   public void changeNew()
    {

        A.Play();
       
    }
}
