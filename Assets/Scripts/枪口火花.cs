using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 枪口火花 : MonoBehaviour {
    bool b = false;
	// Use this for initialization
	void Start () {
        b = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(b)
        Destroy(GetComponent<Light>());
        b = true;
	}
}
