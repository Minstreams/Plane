﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主武器父类
/// </summary>
public abstract class PrimaryWeapon : ICPWeapon, Transformable
{
    //通用部署代码-----------------------
    /// <summary>
    /// 副武器位置L
    /// </summary>
    [Header("【主武器结构】")]
    public Transform secondaryWeaponPositionL;
    /// <summary>
    /// 副武器位置R
    /// </summary>
    public Transform secondaryWeaponPositionR;
    /// <summary>
    /// 核心位置
    /// </summary>
    public Transform corePosition;

}
