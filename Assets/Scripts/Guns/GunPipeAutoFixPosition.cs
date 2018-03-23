using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPipeAutoFixPosition : MonoBehaviour {
    public float fixRate=0.1f;
    Vector3 target;
	// Use this for initialization
	void Start () {
        target = transform.localPosition;

    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += (target - transform.localPosition) * fixRate;
    }
}
