using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlink : MonoBehaviour
{
    public int blinkingInFrames;
    public int blinkingOutFrames;
    public Color targetColor;
    int isBlinking;
    Material mt;
    Color c;
    public Color oc;
    public int timer;
    // Use this for initialization
    void Start()
    {
        timer = 0;
        mt = GetComponent<Renderer>().material;
        oc = mt.GetColor("_TintColor");
        c = oc;
        isBlinking = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlinking == 1)
        {
            c += (targetColor - oc) / blinkingInFrames;
            mt.SetColor("_TintColor", c);
            timer++;
            if (timer >= blinkingInFrames)
            {
                isBlinking = -1;
                timer = 0;
            }
        }
        else if (isBlinking == -1)
        {
            c -= (targetColor - oc) / blinkingOutFrames;
            mt.SetColor("_TintColor", c);
            timer++;
            if (timer >= blinkingOutFrames)
            {
                isBlinking = 0;
                timer = 0;
            }
        }
    }
    public void BlinkOnce()
    {
        mt.SetColor("_TintColor", oc);
        c = oc;
        isBlinking = 1;
        timer = 0;
    }
}
