using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleChanger : MonoBehaviour {
    public float changingRate=0.01f;
    public bool isChanging;
    float target;
    float current;
    public Renderer m1;
    public Renderer m2;
    // Use this for initialization
    void Start () {
        current= transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (isChanging)
        {
            current += (target - current) * changingRate;
            m1.material.SetColor("_TintColor", new Color(0.5f * (1 - current), 0.5f * current, 0.5f * current));
            m2.material.SetColor("_TintColor", new Color(0.5f * (1 - current), 0.5f * current, 0.5f * current));
            transform.localScale = new Vector3(current, 1, 1);
            if (current - target<= 0.001f&&current-target>=-0.001f) isChanging = false;
        }
	}
    public void ChangeTo(float t)
    {
        isChanging = true;
        target = t;
    }
}
