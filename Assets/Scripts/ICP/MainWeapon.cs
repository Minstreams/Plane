using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主武器父类
/// </summary>
public abstract class MainWeapon : Weapon {

    /// <summary>
    /// 副武器位置L
    /// </summary>
    public Transform accessaryWeaponPositionL;
    /// <summary>
    /// 副武器位置R
    /// </summary>
    public Transform accessaryWeaponPositionR;
    /// <summary>
    /// 核心位置
    /// </summary>
    public Transform corePosition;
}
