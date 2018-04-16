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
        public class Setting
        {
            /// <summary>
            /// 友军伤害
            /// </summary>
            [Header("友军伤害")]
            public bool friendlyFire = false;
            /// <summary>
            /// 允许结盟
            /// </summary>
            [Header("允许结盟")]
            public bool allowAlliance = false;
        }

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
        /// <summary>
        /// 结盟数据记录
        /// </summary>
        private static bool[] CampAllianceList = new bool[System.Enum.GetValues(typeof(Camp)).Length * (System.Enum.GetValues(typeof(Camp)).Length - 1) / 2];



        //方法--------------------------------
        /// <summary>
        /// 清空结盟状态
        /// </summary>
        public static void ResetAlliance()
        {
            CampAllianceList.Initialize();
        }
        /// <summary>
        /// 使结盟
        /// </summary>
        public static void Ally(Camp campL, Camp campR)
        {
            if (campL == campR) return;
            CampAllianceList[MathSystem.UpTriangleIndex((int)campL, (int)campR)] = true;
        }
        /// <summary>
        /// 解除结盟
        /// </summary>
        public static void Dissolve(Camp campL, Camp campR)
        {
            if (campL == campR)
            {
                Debug.LogError("无法和自己阵营解除同盟关系！");
                return;
            }
            CampAllianceList[MathSystem.UpTriangleIndex((int)campL, (int)campR)] = false;
        }
        /// <summary>
        /// 是否结盟
        /// </summary>
        public static bool areAllied(Camp campL, Camp campR)
        {
            if (campL == campR) return true;
            return CampAllianceList[MathSystem.UpTriangleIndex((int)campL, (int)campR)];
        }
        /// <summary>
        /// 是否可造成伤害
        /// </summary>
        public static bool ableToDamage(Camp campL, Camp campR)
        {
            if (Setting.friendlyFire) return true;
            if (campL == campR) return false;
            if (!Setting.allowAlliance) return true;
            return !areAllied(campL, campR);
        }
    }
}