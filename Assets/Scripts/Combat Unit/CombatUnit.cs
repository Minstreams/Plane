using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作战单位单位 Combat Unit
/// </summary>
public abstract class CombatUnit : MonoBehaviour {
    /// <summary>
    /// 阵营
    /// </summary>
    public WarSystem.Camp camp;

    /// <summary>
    /// 固定参数
    /// </summary>
    public struct Data
    {

    }

    public float Health = 100;

    public void Harmed(float harm)
    {
        Health -= harm;
        if (Health <= 0)
        {

        }
    }

    public abstract void Die();
}
