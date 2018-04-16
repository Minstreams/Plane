using System;
using System.Collections;
using System.Collections.Generic;
using GameSystem;
using UnityEngine;

public class SecondaryWeaponTest : SecondaryWeapon
{
    //参数----------------------------------
    [System.Serializable]
    public class Parameters : GameSystem.WeaponSystem.ParametersData
    {
        public WeaponSystem.BulletData bulletData;
    }

    private Parameters parameters { get { return GameSystem.WeaponSystem.Setting.secondaryWeaponList.test1; } }
    protected override RotateParameters rotateParameters { get { return parameters.rotateParameters; } }
    public override WeaponSystem.BulletData BulletData { get { return parameters.bulletData; } }
    public override WarSystem.Camp Camp { get { return icp.Camp; } }





    //结构----------------------------------
    public Transform bodyL;
    public Transform bodyR;







    //实现----------------------------------
    protected override void Rotate(Quaternion hRotation, Quaternion vRotation)
    {
        Quaternion rotation = hRotation * vRotation;

        bodyL.rotation = rotation;
        bodyR.rotation = rotation;
    }

    protected override void OnLaunch()
    {
        throw new NotImplementedException();
    }

    protected override void OnStopLaunching()
    {
        throw new NotImplementedException();
    }
}
