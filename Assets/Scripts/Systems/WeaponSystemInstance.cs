using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    /// <summary>
    /// 武器系统
    /// </summary>
    [DisallowMultipleComponent]
    public class WeaponSystemInstance : SystemInstance<WeaponSystemInstance>
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
            public PrimaryWeaponList primaryWeaponList;
            [Header("副武器参数")]
            public SecondaryWeaponList secondaryWeaponList;
        }

        public Setting setting;




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
        public struct PrimaryWeaponList
        {
            public PrimaryWeaponTest1.Parameters test1;
        }



        //副武器--------------------------------------------------------------
        //结构体表列
        [System.Serializable]
        public struct SecondaryWeaponList
        {
            public SecondaryWeaponTest.Parameters test1;
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
        private static GameSystemInstance.WeaponSystemInstance Instance { get { return GameSystemInstance.WeaponSystemInstance.Instance; } }

        //常量--------------------------------
        /// <summary>
        /// 子弹消失时间（s）
        /// </summary>
        public const float bulletDieSeconds = 1;


        //结构--------------------------------
        /// <summary>
        /// 装甲参数结构
        /// </summary>
        [System.Serializable]
        public class ArmorData
        {
            [Header("最大结构耐久")]
            public float maxPhysicHP = 100;
            [Header("最大护盾耐久")]
            public float maxSheildHP = 100;
            [Header("重甲系数%"), Range(0, 100), SerializeField]
            private int armorStrength = 0;
            public float ArmorStrength { get { return armorStrength / 100.0f; } }
            [Header("护盾防御系数%"), Range(0, 100), SerializeField]
            private int shieldDefence = 90;
            public float ShieldDefence { get { return shieldDefence / 100.0f; } }
            /// <summary>
            /// 是否破盾
            /// </summary>
            [HideInInspector]
            public bool isShieldBroken;
        }

        /// <summary>
        /// 伤害数据结构
        /// </summary>
        [System.Serializable]
        public class BulletData
        {
            [Header("结构伤害")]
            public float physicDamage = 10;
            [Header("护盾伤害")]
            public float shieldDamage = 0;
            [Header("穿甲系数%"), Range(0, 100), SerializeField]
            private int armorPiercingRate = 0;
            public float ArmourPiercingRate { get { return armorPiercingRate / 100.0f; } }
            [Header("破盾系数"), Range(0, 100), SerializeField]
            private int shieldPenetratingRate = 0;
            public float ShieldPenetratingRate { get { return shieldPenetratingRate / 100.0f; } }
        }

        /// <summary>
        /// 作战单位耐久度结构
        /// </summary>
        public struct HP
        {
            // 构造函数
            public HP(float physicHP, float shieldHP)
            {
                PhysicHP = physicHP;
                ShieldHP = shieldHP;
            }
            // 重载操作符
            public static HP operator +(HP lhs, HP rhs)
            {
                return new HP(lhs.PhysicHP + rhs.PhysicHP, lhs.ShieldHP + rhs.ShieldHP);
            }
            public static HP operator -(HP lhs, HP rhs)
            {
                return new HP(lhs.PhysicHP - rhs.PhysicHP, lhs.ShieldHP - rhs.ShieldHP);
            }
            public float PhysicHP;
            public float ShieldHP;
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
        public enum PrimaryWeaponEnum
        {
            test1
        }
        /// <summary>
        /// 副武器型号
        /// </summary>
        public enum SecondaryWeaponEnum
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
        public static GameObject getPrefab(PrimaryWeaponEnum primaryWeaponName)
        {
            switch (primaryWeaponName)
            {
                case PrimaryWeaponEnum.test1:
                    return Setting.primaryWeaponList.test1.prefab;
                default:
                    Debug.Log(primaryWeaponName + " prefab not found!");
                    return null;
            }
        }
        /// <summary>
        /// 获取副武器Prefab
        /// </summary>
        public static GameObject getPrefab(SecondaryWeaponEnum secondaryWeaponName)
        {
            switch (secondaryWeaponName)
            {
                case SecondaryWeaponEnum.test1:
                    return Setting.secondaryWeaponList.test1.prefab;
                default:
                    return null;
            }
        }
        /// <summary>
        /// 伤害计算
        /// </summary>
        /// <param name="armor">装甲数据</param>
        /// <param name="bullet">子弹数据</param>
        public static HP Damage(ArmorData armor, BulletData bullet)
        {
            if (armor.isShieldBroken)
            {
                return new HP
                    (
                        bullet.physicDamage * (1 - armor.ArmorStrength * (1 - bullet.ArmourPiercingRate)),
                        0
                    );
            }
            else
            {
                return new HP
                    (
                        bullet.physicDamage * bullet.ShieldPenetratingRate * (1 - armor.ArmorStrength * (1 - bullet.ArmourPiercingRate)),
                        bullet.shieldDamage + bullet.physicDamage * (1 - armor.ShieldDefence) * (1 - bullet.ShieldPenetratingRate)
                    );
            }
        }
    }
}