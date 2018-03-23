using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
    public int blinkingInFrames;
    public int blinkingOutFrames;
    public float maxFading;
    int isBlinking;
    Material mt;
    Color c;
	// Use this for initialization
	void Start () {
        mt = GetComponent<Renderer>().material;
        c = mt.GetColor("_TintColor");
        c.a = 0;
        mt.SetColor("_TintColor", c);
        isBlinking = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (isBlinking == 1)
        {
            c.a += maxFading / blinkingInFrames;
            mt.SetColor("_TintColor", c);
            if (c.a >= maxFading) isBlinking = -1;
        }
        else if(isBlinking==-1)
        {
            c.a -= maxFading / blinkingOutFrames;
            mt.SetColor("_TintColor", c);
            if (c.a <= 0) isBlinking = 0;
        }
	}
    public void BlinkOnce()
    {
        isBlinking = 1;
        GetComponent<AudioSource>().Play();
    }
}
