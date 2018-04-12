using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    /// <summary>
    /// 武器系统
    /// </summary>
    [DisallowMultipleComponent]
    public class WeaponSystemInstance : MonoBehaviour
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
        }

        public Setting setting;
        private void Awake() { GameSystem.WeaponSystem.Instance = this; }



        //底座----------------------------------------------------------------
        //结构体表列
        [System.Serializable]
        public struct WeaponBottomList
        {
            public WeaponBottomTest.Parameters test1;
        }



        //主武器--------------------------------------------------------------
        //结构体表列
        [System.Serializable]
        public struct MainWeaponList
        {
            public MainWeaponTest1.Parameters test1;
        }



        //副武器--------------------------------------------------------------
        //结构体表列
        [System.Serializable]
        public struct AccessaryWeaponList
        {
            public AccessaryWeaponTest.Parameters test1;
        }
    }
}

namespace GameSystem
{
    /// <summary>
    /// 武器系统
    /// </summary>
    public static class WeaponSystem
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        public static GameSystemInstance.WeaponSystemInstance.Setting Setting { get { return Instance.setting; } }
        /// <summary>
        /// 实例
        /// </summary>
        public static GameSystemInstance.WeaponSystemInstance Instance { private get; set; }


        //结构--------------------------------
        /// <summary>
        /// 参数结构
        /// </summary>
        /// <typeparam name="T">其它参数类型</typeparam>
        public class ParametersData
        {
            public GameObject prefab;
            [Header("视角控制通用参数：")]
            public ICPUnit.RotateParameters rotateParameters;
        }

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
        public static GameObject getPrefab(WeaponBottomEnum weaponBottomName)
        {
            switch (weaponBottomName)
            {
                case WeaponBottomEnum.test1:
                    return Setting.weaponBottomList.test1.prefab;
                default:
                    return null;
            }
        }
        /// <summary>
        /// 获取主武器Prefab
        /// </summary>
        public static GameObject getPrefab(MainWeaponEnum mainWeaponName)
        {
            switch (mainWeaponName)
            {
                case MainWeaponEnum.test1:
                    return Setting.mainWeaponList.test1.prefab;
                default:
                    return null;
            }
        }
        /// <summary>
        /// 获取副武器Prefab
        /// </summary>
        public static GameObject getPrefab(AccessaryWeaponEnum accessaryWeaponName)
        {
            switch (accessaryWeaponName)
            {
                case AccessaryWeaponEnum.test1:
                    return Setting.accessaryWeaponList.test1.prefab;
                default:
                    return null;
            }
        }

    }
}