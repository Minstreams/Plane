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
    [System.Serializable]
    private struct WeaponBottomPrefabList
    {
        public GameObject test1;
    }
    [Header("底座Prefab")]
    [SerializeField]
    private WeaponBottomPrefabList weaponBottomPrefabList;


    /// <summary>
    /// 主武器型号
    /// </summary>
    public enum MainWeaponEnum
    {
        test1
    }
    [System.Serializable]
    private struct MainWeaponPrefabList
    {
        public GameObject test1;
    }
    [Header("主武器Prefab")]
    [SerializeField]
    private MainWeaponPrefabList mainWeaponPrefabList;


    /// <summary>
    /// 副武器型号
    /// </summary>
    public enum AccessaryWeaponEnum
    {
        test1
    }
    [System.Serializable]
    private struct AccessaryWeaponPrefabList
    {
        public GameObject test1;
    }
    [Header("副武器Prefab")]
    [SerializeField]
    private AccessaryWeaponPrefabList accessaryWeaponPrefabList;


    //方法--------------------------------
    /// <summary>
    /// 获取底座Prefab
    /// </summary>
    public GameObject getPrefab(WeaponBottomEnum weaponBottomName)
    {
        switch (weaponBottomName)
        {
            case WeaponBottomEnum.test1:
                return weaponBottomPrefabList.test1;
            default:
                return null;
        }
    }
    /// <summary>
    /// 获取主武器Prefab
    /// </summary>
    public GameObject getPrefab(MainWeaponEnum mainWeaponName)
    {
        switch (mainWeaponName)
        {
            case MainWeaponEnum.test1:
                return mainWeaponPrefabList.test1;
            default:
                return null;
        }
    }
    /// <summary>
    /// 获取副武器Prefab
    /// </summary>
    public GameObject getPrefab(AccessaryWeaponEnum accessaryWeaponName)
    {
        switch (accessaryWeaponName)
        {
            case AccessaryWeaponEnum.test1:
                return accessaryWeaponPrefabList.test1;
            default:
                return null;
        }
    }

}
