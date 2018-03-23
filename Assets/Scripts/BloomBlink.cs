using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class BloomBlink : MonoBehaviour
{
    public int blinkingInFrames;
    public int blinkingOutFrames;
    float maxFading;
    int isBlinking;
    float of;
    float f;
    Bloom b;
    // Use this for initialization
    void Start()
    {
        b = GetComponent<Bloom>();
        of = b.bloomThreshold;
        f = of;
        isBlinking = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlinking == 1)
        {
            f -= maxFading / blinkingInFrames;
            b.bloomThreshold = f;
            b.lensflareThreshold = f;
            if (f <= of - maxFading) isBlinking = -1;
        }
        else if (isBlinking == -1)
        {
            f += maxFading / blinkingOutFrames;
            b.bloomThreshold = f;
            b.lensflareThreshold = f;
            if (f>=of) isBlinking = 0;
        }
    }
    public void BlinkOnce(float m)
    {
        maxFading = m;
        f = of;
        isBlinking = 1;
    }
}
