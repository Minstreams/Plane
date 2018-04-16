using System;
using System.Collections;
using System.Collections.Generic;
using GameSystem;
using UnityEngine;

/// <summary>
/// 作战单位单位 Combat Unit
/// </summary>
public abstract class CombatUnit : DestroibleObject
{
    //变量--------------------------------------
    [Header("阵营"), SerializeField]
    private WarSystem.Camp camp;
    /// <summary>
    /// 阵营
    /// </summary>
    public override WarSystem.Camp Camp
    {
        get
        {
            return camp;
        }
    }

    /// <summary>
    /// 耐久度
    /// </summary>
    public GameSystem.WeaponSystem.HP hp;

    /// <summary>
    /// 核心位置
    /// </summary>
    public abstract Transform corePosition { get; }

    protected virtual void Start()
    {
        hp = new GameSystem.WeaponSystem.HP(Armor.maxPhysicHP, Armor.maxSheildHP);
    }

    public override void Damage(WeaponSystem.HP damage)
    {
        hp -= damage;
        if (!Armor.isShieldBroken && hp.ShieldHP <= 0) ShieldBreak();
        if (hp.PhysicHP <= 0) Die();
    }

    //接口-------------------------------------
    public virtual void ShieldBreak()
    {
        Armor.isShieldBroken = true;
    }
}
