using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 提供BulletUpdate方法的高级Behaviour(Update禁用)
/// </summary>
public abstract class BulletTimeFixedBehaviour : BulletTimeBehaviour
{
    //实现----------------------------------
    private float timer = 0;
    /// <summary>
    /// 固定DeltaTime
    /// </summary>
    protected sealed override float DeltaTime
    {
        get
        {
            return BulletTimeSystem.BulletUpdateTimeInterVal;
        }
    }

    /// <summary>
    /// 密封Update
    /// </summary>
    protected sealed override void Update()
    {
        timer += BulletTimeSystem.TimeScale * Time.deltaTime;
        while (timer > BulletTimeSystem.BulletUpdateTimeInterVal)
        {
            timer -= BulletTimeSystem.BulletUpdateTimeInterVal;
            BulletUpdate();
        }
    }



    //接口----------------------------------
    /// <summary>
    /// 定时调用
    /// </summary>
    protected abstract void BulletUpdate();
}
