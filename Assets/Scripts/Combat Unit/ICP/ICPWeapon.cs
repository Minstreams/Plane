using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ICP搭载武器
/// </summary>
public abstract class ICPWeapon : ICPUnit, Weapon
{
    //控制方法--------------------------------
    /// <summary>
    /// 开炮
    /// </summary>
    public abstract void Launch();





    //事件表列--------------------------------
    /// <summary>
    /// 发射
    /// </summary>
    public event Action onLaunch;
    /// <summary>
    /// 命中敌人
    /// </summary>
    public event Action onEnemyHit;
}
