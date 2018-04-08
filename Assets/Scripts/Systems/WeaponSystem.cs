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
    /// 参数结构
    /// </summary>
    /// <typeparam name="T">其它参数类型</typeparam>
    [System.Serializable]
    public class ParametersData<OtherParameters>
    {
        public GameObject prefab;
        public ICPUnit.RotateParameters rotateParameters;
        public OtherParameters otherParameters;
    }

    /// <summary>
    /// 底座型号
    /// </summary>
    public enum WeaponBottomEnum
    {
        test1
    }

    //序列化列表
    [System.Serializable]
    public class ParameterTest1 : ParametersData<WeaponBottomTest.OtherParameters> { }


    [System.Serializable]
    public struct WeaponBottomList
    {
        public ParameterTest1 test1;
    }


    [Header("底座参数")]
    public WeaponBottomList weaponBottomList;


    /// <summary>
    /// 主武器型号
    /// </summary>
    public enum MainWeaponEnum
    {
        test1
    }
    [System.Serializable]
    public struct MainWeaponList
    {
        public ParametersData<MainWeaponTest1.OtherParameters> test1;
    }
    [Header("主武器参数")]
    [SerializeField]
    public MainWeaponList mainWeaponList;


    /// <summary>
    /// 副武器型号
    /// </summary>
    public enum AccessaryWeaponEnum
    {
        test1
    }
    [System.Serializable]
    public struct AccessaryWeaponList
    {
        public ParametersData<AccessaryWeaponTest.OtherParameters> test1;
    }
    [Header("副武器参数")]
    [SerializeField]
    public AccessaryWeaponList accessaryWeaponList;


    //方法--------------------------------
    /// <summary>
    /// 获取底座Prefab
    /// </summary>
    public GameObject getPrefab(WeaponBottomEnum weaponBottomName)
    {
        switch (weaponBottomName)
        {
            case WeaponBottomEnum.test1:
                return weaponBottomList.test1.prefab;
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
                return mainWeaponList.test1.prefab;
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
                return accessaryWeaponList.test1.prefab;
            default:
                return null;
        }
    }

}
