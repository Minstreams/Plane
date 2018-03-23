using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 火花 : MonoBehaviour {
    public float fadeSpeed=0.3f;
    int fadeFrames;
    int timer = 0;
	// Use this for initialization
	void Start () {
        fadeFrames = (int)(fadeSpeed / Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (timer>=fadeFrames) Destroy(this.gameObject);
	}
}
