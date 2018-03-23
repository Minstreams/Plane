using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class skyboxControl : MonoBehaviour {
    public Transform dLight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dLight.Rotate(new Vector3(1, 0, 0));
	}
}
