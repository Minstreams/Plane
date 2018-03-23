using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhunxinKuoSan : MonoBehaviour {
    public Transform p1;
    public Transform p2;
    public Transform p3;
    Vector3 originX;
    Vector3 x;
    public float recoverRate;
    // Use this for initialization
    void Start () {
        x = originX = p1.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        x += (originX - x) * recoverRate;
        p1.localPosition = p2.localPosition = p3.localPosition = x;
	}
    public void setX(float xx)
    {
        x -=new Vector3(xx, 0, 0);
    }
}
