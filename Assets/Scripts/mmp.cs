using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmp : MonoBehaviour {
    public mmps ms;
    public Aim aim;
    public GameObject mudan;
    public Transform target;
    public float power;
    public float backPower;
    Vector3 launchRotation;
    bool isLeft=true;

	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            launchRotation = -transform.forward * power;
            if (isLeft) launchRotation = -launchRotation;
            launchRotation += transform.right;
            Launch(transform.position+new Vector3(0,1f,0),launchRotation);
            isLeft = !isLeft;
        }
	}
    void Launch(Vector3 p,Vector3 r)
    {
        if (ms.DeleteOne())
        {
            target = aim.target;
            if (target != null) aim.GetComponent<ColorBlink>().BlinkOnce();
            transform.localPosition -= new Vector3(0, 0, backPower);
            GameObject g = GameObject.Instantiate(mudan, p, Quaternion.FromToRotation(Vector3.zero, r));
            g.GetComponent<dan>().target = target;
            g.GetComponent<dan>().v = r;
            g.GetComponent<dan>().fixVo();
        }
    }
}
