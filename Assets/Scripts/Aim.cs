using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {
    RaycastHit rh;
    public Camera mainC;
    public Camera UIc;
    Vector3 center;
    Vector3 originScale;
    public Transform target;
	// Use this for initialization
	void Start () {
        originScale = transform.localScale;
        target = null;
        center = new Vector3(mainC.pixelWidth / 2, mainC.pixelHeight / 2, 10);
	}
	
	// Update is called once per frame
	void Update () {
        Ray r = mainC.ScreenPointToRay(center);
        if(Physics.Raycast(r, out rh, 200,1<<LayerMask.NameToLayer("Enemy")))
        {
            target = rh.rigidbody.transform;
        }
        if (target != null)
        {
            transform.position = UIc.ScreenToWorldPoint(mainC.WorldToScreenPoint(target.position)) + new Vector3(0, 0, 10);
            transform.localScale = originScale * 25 / target.position.z;
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
        }
	}
}
