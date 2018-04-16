using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器底座
/// </summary>
public abstract class WeaponBottom : ICPComponent, Transformable
{
    //通用部署代码-----------------------
    /// <summary>
    /// 主武器位置
    /// </summary>
    [Header("【底座结构】")]
    public Transform primaryWeaponPosition;





    //控制方法--------------------------

    /// <summary>
    /// 移动控制
    /// </summary>
    /// <param name="h">水平输入量</param>
    /// <param name="v">垂直输入量</param>
    public abstract void Move(float h, float v);
}
