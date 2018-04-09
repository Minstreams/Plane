using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("AccessaryWeapon/Test")]
public class AccessaryWeaponTest : AccessaryWeapon
{
    //参数----------------------------------
    [System.Serializable]
    public struct OtherParameters
    {

    }

    private OtherParameters parameters { get { return GameSystem.weaponSystem.setting.accessaryWeaponList.test1.otherParameters; } }
    protected override RotateParameters rotateParameters
    {
        get
        {
            return GameSystem.weaponSystem.setting.accessaryWeaponList.test1.rotateParameters;
        }
    }





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
