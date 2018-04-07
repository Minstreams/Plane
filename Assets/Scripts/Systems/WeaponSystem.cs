using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器系统
/// </summary>
[DisallowMultipleComponent]
public class WeaponSystem : MonoBehaviour
{
    //参数--------------------------------
    [System.Serializable]
    public struct Setting
    {

    }
    [Header("【武器系统】")]
    [Header("参数设置：")]
    public Setting setting;

    //属性--------------------------------
    /// <summary>
    /// 底座型号
    /// </summary>
    public enum WeaponBottomEnum
    {
        test1
    }

    /// <summary>
    /// 主武器型号
    /// </summary>
    public enum MainWeaponEnum
    {
        test1
    }

    /// <summary>
    /// 副武器型号
    /// </summary>
    public enum AccessaryWeaponEnum
    {
        test1
    }



    //方法--------------------------------
    /// <summary>
    /// 获取底座Prefab
    /// </summary>
    public GameObject getPrefab(WeaponBottomEnum weaponBottomName)
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// 获取主武器Prefab
    /// </summary>
    public GameObject getPrefab(MainWeaponEnum mainWeaponName)
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// 获取副武器Prefab
    /// </summary>
    public GameObject getPrefab(AccessaryWeaponEnum accessaryWeaponName)
    {
        throw new System.NotImplementedException();
    }

}
