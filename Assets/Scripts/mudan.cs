using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mudan : MonoBehaviour {
    public float splitTime=1;
    public int splitNumber=5;
    public GameObject zidan;
    public float power=5;
    int splitFrames;
    int timer = 0;

    AudioSource aus;
	// Use this for initialization
	void Start () {
        aus = GameObject.FindGameObjectWithTag("mmpAudio").GetComponent<AudioSource>();
        aus.Play();
        splitFrames = (int)(splitTime / Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (timer >= splitFrames) Split();
	}
    void Split()
    {
        float zRotate = 360/splitNumber;
        Quaternion q = Quaternion.AngleAxis(zRotate, transform.forward);
        Vector3 v = transform.up;
        for(int i = 1; i <= splitNumber; i++)
        {
            GameObject g = GameObject.Instantiate(zidan, transform.position, Quaternion.AngleAxis(zRotate*i, transform.forward));
            v = q*v;
            g.GetComponent<dan>().target = GetComponent<dan>().target;
            g.GetComponent<dan>().v = v * power+ GetComponent<dan>().v*1.2f;
            g.GetComponent<dan>().fixVo();
            if (i == 1)
            {
                g.GetComponent<AudioSource>().Play();
            }
        }
        Destroy(gameObject);
    }
}
