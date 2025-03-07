using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("ScaleUp", 0.5f, 1f);
        InvokeRepeating("ScaleDown", 0.6f, 1f);
        InvokeRepeating("ScaleUp", 0.75f, 1f);
        InvokeRepeating("ScaleDown", 0.85f, 1f);
    }
	
    void ScaleUp()
    {
        transform.localScale *= 1.3f;
    }

    void ScaleDown()
    {
        transform.localScale /= 1.3f;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
