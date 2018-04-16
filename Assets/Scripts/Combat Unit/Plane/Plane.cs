using System;
using System.Collections;
using System.Collections.Generic;
using GameSystem;
using UnityEngine;

/// <summary>
/// 敌机
/// </summary>
public class Plane : CombatUnit {
    public override WeaponSystem.ArmorData Armor
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public override Transform corePosition
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    //不要求碰撞箱组件
    //为了性能考虑，避免使用MeshCollider

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
