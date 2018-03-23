using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRotate : MonoBehaviour
{
    public float rRate=0.1f;
    Transform hr;
    // Use this for initialization
    void Start()
    {
        hr = GameObject.FindGameObjectWithTag("HRotation").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Toin180(hr.localEulerAngles.y - transform.localEulerAngles.y)) * rRate;
        transform.Rotate(new Vector3(0, t, 0));
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
