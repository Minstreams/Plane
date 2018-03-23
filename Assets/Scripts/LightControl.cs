using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {
    public Material mt01;
    public Material mt02;
    public Material mt03;
    public Material mt04;
    public Material mt05;
    TimeControl tc;
    public float f=0;
    public float startTime01;
    public float endTime01;
    public float startTime02;
    public float endTime02;
    float delta01;
    float delta02;
    // Use this for initialization
    void Start () {
        tc = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeControl>();
        delta01 = Time.deltaTime / (endTime01 - startTime01);
        delta02 = Time.deltaTime / (endTime02 - startTime02);
    }
	
	// Update is called once per frame
	void Update () {
        if (tc.seconds <= 1f)
        {
            setF(0);
            f = 0;
        }
        if (tc.seconds >= startTime01 && tc.seconds <= endTime01)
        {
            f += delta01;
        }
        if (tc.seconds >= startTime02 && tc.seconds <= endTime02)
        {
            f -= delta02;
        }
        setF(f);
    }
    public void setF(float ff)
    {
        mt01.SetColor("_EmissionColor", new Color(ff, ff, ff));
        mt02.SetColor("_EmissionColor", new Color(ff, ff, ff));
        mt03.SetColor("_EmissionColor", new Color(ff, ff, ff));
        mt04.SetColor("_EmissionColor", new Color(ff, ff, ff));
        mt05.SetColor("_EmissionColor", new Color(ff, ff, ff));
    }
}
