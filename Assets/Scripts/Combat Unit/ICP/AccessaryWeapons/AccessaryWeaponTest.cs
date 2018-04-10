using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("AccessaryWeapon/Test")]
public class AccessaryWeaponTest : AccessaryWeapon
{
    //参数----------------------------------
    [System.Serializable]
    public class Parameters : WeaponSystem.ParametersData
    {

    }

    private Parameters parameters { get { return GameSystem.weaponSystem.accessaryWeaponList.test1; } }
    protected override RotateParameters rotateParameters { get { return parameters.rotateParameters; } }





    //结构----------------------------------
    public Transform bodyL;
    public Transform bodyR;







    //实现----------------------------------
    public override void Launch()
    {
        throw new NotImplementedException();
    }

    protected override void Rotate(Quaternion hRotation, Quaternion vRotation)
    {
        Quaternion rotation = hRotation * vRotation;

        bodyL.rotation = rotation;
        bodyR.rotation = rotation;
    }
}
