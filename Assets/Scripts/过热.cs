using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 过热 : MonoBehaviour {
    public float f;
    public float fd;
    public Renderer m1;
    public Renderer m2;
    public Renderer m3;
    public Renderer m4;
    bool isOverLoading=false;
    public Gun g;
    public Gun g2;
    // Use this for initialization
    void Start () {
        f = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (f > fd) f -= fd; else Recover();
        if (f >= 1) OverLoad();
        transform.localScale = new Vector3(1, f, 1);
        m1.material.SetColor("_TintColor", new Color(0.5f, 0.5f * (1 - f), 0));
        m2.material.SetColor("_TintColor", new Color(0.5f, 0.5f * (1 - f), 0));
        m3.material.SetColor("_TintColor", new Color(0.5f, 0.5f * (1 - f), 0));
        m4.material.SetColor("_TintColor", new Color(0.5f, 0.5f * (1 - f), 0));
    }

    void OverLoad()
    {
        isOverLoading = true;
        g.Stop();
        g2.Stop();
        GetComponent<AudioSource>().Play();
    }

    void Recover()
    {
        if (isOverLoading)
        {
            g.enabled = true;
            g2.enabled = true;
            isOverLoading = false;
            g.GetComponent<AudioSource>().Play();
        }
    }
}
