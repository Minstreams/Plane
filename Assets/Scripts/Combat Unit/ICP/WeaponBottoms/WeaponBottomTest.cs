using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBottomTest : WeaponBottom
{
    //参数----------------------------------
    [System.Serializable]
    public class Parameters : ParametersData
    {
        public float speed = 2.0f;
    }

    private Parameters parameters { get { return GameSystem.WeaponSystem.Setting.weaponBottomList.test1; } }
    protected override RotateParameters rotateParameters { get { return parameters.rotateParameters; } }





    //结构----------------------------------
    public Transform body;






    //实现----------------------------------
    public override void Move(float h, float v)
    {
        //先这样吧，能走就行
        icp.transform.Translate(body.forward * Vector3.Dot(body.forward, icp.corePosition.right * h + icp.corePosition.forward * v) * Time.deltaTime * GameSystem.BulletTimeSystem.TimeScale);
    }

    protected override void Rotate(Quaternion hRotation, Quaternion vRotation)
    {
        body.localRotation = hRotation;
    }
}
