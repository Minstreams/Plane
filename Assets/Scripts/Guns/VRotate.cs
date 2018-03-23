using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRotate : MonoBehaviour {
    public float rRate=0.1f;
    Transform vr;
	// Use this for initialization
	void Start () {
        vr = GameObject.FindGameObjectWithTag("VRotation").transform;
	}
	
	// Update is called once per frame
	void Update () {
        float t= (Toin180(vr.localEulerAngles.x-transform.localEulerAngles.x))*rRate;
        transform.Rotate(new Vector3(t,0,0));
	}
    float Toin180(float n)
    {
        while (n > 180)
        {
            n -= 360;
        }
        while (n < -180)
        {
            n += 360;
        }
        return n;
    }
}
