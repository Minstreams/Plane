using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 简单封装MonoBehaviour实现线性时间减慢效果
/// </summary>
public abstract class BulletTimeBehaviour : MonoBehaviour
{
    /// <summary>
    /// 按照时间拉伸系数修正后的DeltaTime
    /// </summary>
    protected virtual float DeltaTime { get { return BulletTimeSystem.TimeScale * Time.deltaTime; } }

    protected abstract void Update();
}
