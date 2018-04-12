using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹类
/// </summary>
[RequireComponent(typeof(SphereCollider))]
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 伤害属性
    /// </summary>
    public struct Data
    {

    }

    private Data data;


    private void OnTriggerEnter(Collider other)
    {
        //敌人判定&&伤害计算

    }
    private void Reset()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }
}
