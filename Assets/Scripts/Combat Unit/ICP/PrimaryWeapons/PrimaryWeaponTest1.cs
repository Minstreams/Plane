using System;
using System.Collections;
using System.Collections.Generic;
using GameSystem;
using UnityEngine;

/// <summary>
/// 主武器Teste1
/// </summary>
public class PrimaryWeaponTest1 : PrimaryWeapon
{
    //参数----------------------------------
    [System.Serializable]
    public class Parameters : GameSystem.WeaponSystem.ParametersData
    {
        public WeaponSystem.BulletData bulletData;
        public GameObject bulletPrefab;
        public float bulletPower;
    }

    private Parameters parameters { get { return GameSystem.WeaponSystem.Setting.primaryWeaponList.test1; } }
    protected override RotateParameters rotateParameters { get { return parameters.rotateParameters; } }
    public override WeaponSystem.BulletData BulletData { get { return parameters.bulletData; } }
    public override WarSystem.Camp Camp { get { return icp.Camp; } }





    //结构----------------------------------
    public Transform hBody;
    public Transform vBody;



    //实现----------------------------------
    protected override void Rotate(Quaternion hRotation, Quaternion vRotation)
    {
        hBody.rotation = hRotation;
        vBody.localRotation = vRotation;
    }

    protected override void OnLaunch()
    {
        throw new NotImplementedException();
    }

    protected override void OnStopLaunching()
    {
        throw new NotImplementedException();
    }


    //测试
    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter!");
    }
}
