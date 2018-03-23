using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAmmo : MonoBehaviour {
    float disappearTime = 1;
    int disappearFrames = 0;
    int timer = 0;
	// Use this for initialization
	void Start () {
        disappearFrames = (int)(disappearTime / Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (timer >= disappearFrames)
        {
            bong();
        }
	}

    public void bong()
    {
        Destroy(this.gameObject);
    }
}
