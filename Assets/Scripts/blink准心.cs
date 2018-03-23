using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink准心 : MonoBehaviour {
    public ColorBlink cb1;
    public ColorBlink cb2;
    public ColorBlink cb3;
    // Use this for initialization
    public void Blink()
    {
        cb1.BlinkOnce();
        cb2.BlinkOnce();
        cb3.BlinkOnce();
    }
}
