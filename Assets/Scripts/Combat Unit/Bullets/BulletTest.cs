using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 测试子弹
/// </summary>
public class BulletTest : Bullet
{
    [System.NonSerialized]
    public float speed;

    protected override void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime * GameSystem.BulletTimeSystem.TimeScale);
    }
}
