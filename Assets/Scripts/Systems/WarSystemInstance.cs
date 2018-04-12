using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    /// <summary>
    /// 战争系统
    /// </summary>
    [DisallowMultipleComponent]
    public class WarSystemInstance : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("【战争系统（部队统计，阵营分配，仇恨计算）】")]
        public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
        [System.Serializable]
        public class Setting { }

        public Setting setting;
        private void Awake() { GameSystem.WarSystem.Instance = this; }
    }
}


namespace GameSystem
{
    /// <summary>
    /// 战争系统，用于部队统计，阵营分配，仇恨计算
    /// </summary>
    public static class WarSystem
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        private static GameSystemInstance.WarSystemInstance.Setting Setting { get { return Instance.setting; } }
        /// <summary>
        /// 实例
        /// </summary>
        public static GameSystemInstance.WarSystemInstance Instance { private get; set; }


        //结构--------------------------------
        /// <summary>
        /// 阵营
        /// </summary>
        public enum Camp
        {
            Human,
            Stromare
        }

        //变量--------------------------------

        //方法--------------------------------

    }
}