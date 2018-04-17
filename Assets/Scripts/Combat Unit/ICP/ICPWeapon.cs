using System;
using System.Collections;
using System.Collections.Generic;
using GameSystem;
using UnityEngine;

/// <summary>
/// ICP搭载武器
/// </summary>
public abstract class ICPWeapon : ICPComponent, Weapon
{
    //结构------------------------------------
    public class WeaponParametersData : ParametersData
    {
        public WeaponSystem.BulletData bulletData;
        public GameObject bulletPrefab;
    }

    //属性------------------------------------
    public abstract WeaponSystem.BulletData BulletData { get; }
    public abstract WarSystem.Camp Camp { get; }


    //控制方法--------------------------------
    /// <summary>
    /// 开炮
    /// </summary>
    public void Launch()
    {
        if (onLaunch != null) onLaunch();
        OnLaunch();
    }
    /// <summary>
    /// 停止开炮
    /// </summary>
    public void StopLaunching()
    {
        if (onStopLaunching != null) onStopLaunching();
        OnStopLaunching();
    }



    //事件表列--------------------------------
    public event Action onLaunch;
    public event Action onLaunching;
    public event Action onStopLaunching;
    public event Action onHittingEnemy;
    public event Action<int> onValueChangeInt;
    public event Action<float> onValueChangeFloat;
    public event Action<Vector3, Vector3> onPositionDerectionChange;


    //固定方法--------------------------------
    /// <summary>
    /// 调用击中敌人事件
    /// </summary>
    public void OnHittingEnemy()
    {
        if (onHittingEnemy != null) onHittingEnemy();
    }


    //具体实现--------------------------------
    protected abstract void OnLaunch();
    protected abstract void OnStopLaunching();
}
