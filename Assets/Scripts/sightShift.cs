using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sightShift : MonoBehaviour {
    bool isShifting;
    Vector3 target;
    public float shiftingRate;
    public Vector3 originPosition;
    public float originMoveSpeed;
    public Vector3 introductionPosition;
    public float introductionMoveSpeed;
    public Transform hr;
    public Transform vr;
	// Use this for initialization
	void Start () {
        ShiftToIntroduction();
	}
	
	// Update is called once per frame
	void Update () {
        if (isShifting)
        {
            transform.position += shiftingRate * (target - transform.position);
            if ((transform.position - target).magnitude <= 0.01f) isShifting = false;
        }
	}
    public void ShiftToGameVision()
    {
        target = originPosition;
        isShifting = true;
        GetComponent<CameraMove>().SetSpeed(originMoveSpeed, originMoveSpeed);
    }
    public void ShiftToIntroduction()
    {
        hr.rotation = Quaternion.identity;
        vr.rotation = Quaternion.identity;
        target = introductionPosition;
        isShifting = true;
        GetComponent<CameraMove>().SetSpeed(introductionMoveSpeed, introductionMoveSpeed);

    }
}
