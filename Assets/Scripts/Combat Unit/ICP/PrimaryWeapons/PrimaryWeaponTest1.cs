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
    public class Parameters : WeaponParametersData
    {
        public float bulletPower;
        [SerializeField]
        private float fireRate;
        public float fireInterval { get { return 1.0f / fireRate; } }
    }

    private Parameters parameters { get { return GameSystem.WeaponSystem.Setting.primaryWeaponList.test1; } }
    protected override RotateParameters rotateParameters { get { return parameters.rotateParameters; } }
    public override WeaponSystem.BulletData BulletData { get { return parameters.bulletData; } }
    public override WarSystem.Camp Camp { get { return icp.Camp; } }





    //结构----------------------------------
    public Transform hBody;
    public Transform vBody;
    public Transform muzzle;


    //实现----------------------------------
    protected override void Rotate(Quaternion hRotation, Quaternion vRotation)
    {
        hBody.rotation = hRotation;
        vBody.localRotation = vRotation;
    }

    protected override void OnLaunch()
    {
        StartCoroutine(launch());
    }

    protected override void OnStopLaunching()
    {
        StopAllCoroutines();
    }

    private IEnumerator launch()
    {
        while (true)
        {
            BulletTest bullet =
            Instantiate(parameters.bulletPrefab, muzzle.position, muzzle.rotation, null).GetComponent<BulletTest>();
            bullet.speed = parameters.bulletPower;
            bullet.weapon = this;
            yield return new WaitForSeconds(parameters.fireInterval / GameSystem.BulletTimeSystem.TimeScale);
        }
    }

    //测试
    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter!");
    }
}
