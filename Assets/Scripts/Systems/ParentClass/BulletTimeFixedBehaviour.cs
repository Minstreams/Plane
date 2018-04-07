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
    private float TimeInterval = GameSystem.bulletTimeSystem.setting.BulletUpdateTimeInterVal;
    private float timer = 0;
    /// <summary>
    /// 密封Update
    /// </summary>
    protected sealed override void Update()
    {
        timer += DeltaTime;
        while (timer > TimeInterval)
        {
            timer -= TimeInterval;
            BulletUpdate();
        }
    }



    //接口----------------------------------
    /// <summary>
    /// 定时调用
    /// </summary>
    protected abstract void BulletUpdate();
}
