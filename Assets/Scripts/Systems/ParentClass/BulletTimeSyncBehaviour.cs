using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 提供BulletUpdate方法的高级Behaviour(Update禁用)
/// </summary>
public abstract class BulletTimeSycnBehaviour : BulletTimeBehaviour
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
            return GameSystem.BulletTimeSystem.BulletUpdateTimeInterVal;
        }
    }

    protected float SyncDeltaTime
    {
        get
        {
            return 0;
        }
    }

    /// <summary>
    /// 密封Update
    /// </summary>
    protected sealed override void Update()
    {
        timer += GameSystem.BulletTimeSystem.TimeScale * Time.deltaTime;
        while (timer > GameSystem.BulletTimeSystem.BulletUpdateTimeInterVal)
        {
            timer -= GameSystem.BulletTimeSystem.BulletUpdateTimeInterVal;
            BulletUpdate();
        }

        SyncUpdate();
    }



    //接口----------------------------------
    /// <summary>
    /// 定时调用
    /// </summary>
    protected abstract void BulletUpdate();

    /// <summary>
    /// 每帧调用，用于同步！
    /// </summary>
    protected abstract void SyncUpdate();
}
