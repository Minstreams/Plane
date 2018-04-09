﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器系统
/// </summary>
[DisallowMultipleComponent]
public class WeaponSystem : MonoBehaviour
{
#if UNITY_EDITOR
    [Header("【武器系统】")]
    public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
    [System.Serializable]
    public class Setting
    {
        //参数---------------------------------
        [Header("底座参数")]
        public WeaponBottomList weaponBottomList;
        [Header("主武器参数")]
        public MainWeaponList mainWeaponList;
        [Header("副武器参数")]
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
    public Setting setting;



    //参数结构------------------------------------------------------------
    /// <summary>
    /// 参数结构
    /// </summary>
    /// <typeparam name="T">其它参数类型</typeparam>
    public class ParametersData<OtherParameters>
    {
        public GameObject prefab;
        [Header("视角控制通用参数：")]
        public ICPUnit.RotateParameters rotateParameters;
        [Header("其它参数：")]
        public OtherParameters otherParameters;
    }



    //底座----------------------------------------------------------------
    /// <summary>
    /// 底座型号
    /// </summary>
    public enum WeaponBottomEnum
    {
        test1
    }

    //序列化列表
    [System.Serializable]
    public class PWBTest1 : ParametersData<WeaponBottomTest.OtherParameters> { }

    //结构体表列
    [System.Serializable]
    public struct WeaponBottomList
    {
        public PWBTest1 test1;
    }




    //主武器--------------------------------------------------------------
    /// <summary>
    /// 主武器型号
    /// </summary>
    public enum MainWeaponEnum
    {
        test1
    }

    //序列化列表
    [System.Serializable]
    public class PMWTest1 : ParametersData<MainWeaponTest1.OtherParameters> { }

    //结构体表列
    [System.Serializable]
    public struct MainWeaponList
    {
        public PMWTest1 test1;
    }





    //副武器--------------------------------------------------------------
    /// <summary>
    /// 副武器型号
    /// </summary>
    public enum AccessaryWeaponEnum
    {
        test1
    }

    //序列化列表
    [System.Serializable]
    public class PAWTest1 : ParametersData<AccessaryWeaponTest.OtherParameters> { }

    //结构体表列
    [System.Serializable]
    public struct AccessaryWeaponList
    {
        public PAWTest1 test1;
    }







}
