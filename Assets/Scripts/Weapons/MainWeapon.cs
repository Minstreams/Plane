using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主武器父类
/// </summary>
public abstract class MainWeapon : MonoBehaviour {

    /// <summary>
    /// 副武器位置L
    /// </summary>
    public Transform accessaryWeaponPositionL;
    /// <summary>
    /// 副武器位置R
    /// </summary>
    public Transform accessaryWeaponPositionR;





    //控制方法--------------------------
    /// <summary>
    /// 转动视角
    /// </summary>
    /// <param name="horizontalQuaternion">水平四元数</param>
    /// <param name="verticalQuaternion">垂直四元数</param>
    public abstract void Rotate(Quaternion horizontalQuaternion, Quaternion verticalQuaternion);

}
