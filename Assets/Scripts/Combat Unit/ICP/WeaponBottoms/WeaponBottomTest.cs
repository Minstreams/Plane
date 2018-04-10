using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("WeaponBottom/Test")]
public class WeaponBottomTest : WeaponBottom
{
    //参数----------------------------------
    [System.Serializable]
    public class Parameters : WeaponSystem.ParametersData
    {

    }

    private Parameters parameters { get { return GameSystem.weaponSystem.weaponBottomList.test1; } }
    protected override RotateParameters rotateParameters { get { return parameters.rotateParameters; } }





    //结构----------------------------------
    public Transform body;






    //实现----------------------------------


    public override void LaunchMode(bool state)
    {
        throw new NotImplementedException();
    }

    public override void Move(float h, float v)
    {
        throw new NotImplementedException();
    }

    protected override void Rotate(Quaternion hRotation, Quaternion vRotation)
    {
        body.localRotation = hRotation;
    }
}
