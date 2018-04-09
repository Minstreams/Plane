using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("WeaponBottom/Test")]
public class WeaponBottomTest : WeaponBottom
{
    //参数----------------------------------
    [System.Serializable]
    public struct OtherParameters
    {

    }

    private OtherParameters parameters { get { return GameSystem.weaponSystem.weaponBottomList.test1.otherParameters; } }
    protected override RotateParameters rotateParameters
    {
        get
        {
            return GameSystem.weaponSystem.weaponBottomList.test1.rotateParameters;
        }
    }




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
