using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器接口
/// </summary>
public interface Weapon
{
    //属性------------------------------------
    GameSystem.WeaponSystem.BulletData BulletData { get; }
    GameSystem.WarSystem.Camp Camp { get; }

    //控制方法--------------------------------
    void Launch();
    void StopLaunching();
    
    //事件表列--------------------------------
    event System.Action onLaunch;
    event System.Action onStopLaunching;
    event System.Action onHittingEnemy;
    event System.Action<int> onValueChangeInt;
    event System.Action<float> onValueChangeFloat;
    event System.Action<Vector3, Vector3> onPositionDerectionChange;


    //固定方法--------------------------------
    void OnHittingEnemy();
}
