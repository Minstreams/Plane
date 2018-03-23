using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    float horizontalSpeed=2;
    float verticalSpeed=2;
    public Transform hRotate;
    public Transform vRotate;

	void Update () {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        vRotate.Rotate(-v, 0, 0);
        hRotate.Rotate(0, h, 0);
    }
    public void SetSpeed(float h,float v)
    {
        horizontalSpeed = h;
        verticalSpeed = v;
    }

}
