using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可破坏物体
/// </summary>
public abstract class DestroibleObject : MonoBehaviour
{
    /// <summary>
    /// 装甲数据
    /// </summary>
    public abstract GameSystem.WeaponSystem.ArmorData Armor { get; }
    /// <summary>
    /// 阵营
    /// </summary>
    public abstract GameSystem.WarSystem.Camp Camp { get; }


    public abstract void Damage(GameSystem.WeaponSystem.HP damage);
    public abstract void Die();
}
