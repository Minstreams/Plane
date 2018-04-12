using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    /// <summary>
    /// 子弹时间系统
    /// </summary>
    [DisallowMultipleComponent]
    public class BulletTimeSystemInstance : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("【子弹时间系统】")]
        public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
        [System.Serializable]
        public class Setting { }

        public Setting setting;
        private void Awake() { GameSystem.BulletTimeSystem.Instance = this; }


#if UNITY_EDITOR
        //调试方法----------------------------
        [Header("时间拉伸系数")]
        [SerializeField]
        [Range(0, 1)]
        private float timeScaleDebug = 1.0f;

        private void Update()
        {
            GameSystem.BulletTimeSystem.SetTimeScale(timeScaleDebug);
        }
#endif
    }
}

namespace GameSystem
{
    /// <summary>
    /// 子弹时间系统
    /// </summary>
    public static class BulletTimeSystem
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        private static GameSystemInstance.BulletTimeSystemInstance.Setting Setting { get { return Instance.setting; } }
        /// <summary>
        /// 实例
        /// </summary>
        public static GameSystemInstance.BulletTimeSystemInstance Instance { private get; set; }




        //变量--------------------------------
        /// <summary>
        /// 每帧时间间隔默认值(s)
        /// </summary>
        public const float BulletUpdateTimeInterVal = 0.02f;

        public const float OneDividedBulletUpdateTimeInterVal = 1.0f / BulletUpdateTimeInterVal;
        /// <summary>
        /// 时间拉伸系数
        /// </summary>
        public static float TimeScale { get { return timeScale; } }
        private static float timeScale = 1.0f;




        //方法--------------------------------
        /// <summary>
        /// 修改时间拉伸系数
        /// </summary>
        /// <param name="scale">系数(Clamped to 0-1)</param>
        public static void SetTimeScale(float scale)
        {
            //暂时
            timeScale = Mathf.Clamp01(scale);
        }
    }
}