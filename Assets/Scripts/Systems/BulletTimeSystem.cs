using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 子弹时间系统
/// </summary>
[DisallowMultipleComponent]
public class BulletTimeSystem : MonoBehaviour
{
    //参数--------------------------------
    [System.Serializable]
    public struct Setting
    {
        /// <summary>
        /// 每帧时间间隔默认值
        /// </summary>
        [Header("每帧时间间隔默认值")]
        public float BulletUpdateTimeInterVal;
    }
    [Header("【子弹时间系统】")]
    [Header("参数设置：")]
    public Setting setting;

    private void Reset()
    {
        setting.BulletUpdateTimeInterVal = 0.02f;
    }

    //属性--------------------------------
    private static float timeScale = 1.0f;
    /// <summary>
    /// 时间拉伸系数
    /// </summary>
    public static float TimeScale { get { return timeScale; } }



    //方法--------------------------------
    /// <summary>
    /// 修改时间拉伸系数
    /// </summary>
    /// <param name="scale">系数(Clamped to 0-1)</param>
    public void SetTimeScale(float scale)
    {
        //暂时
        timeScale = Mathf.Clamp01(scale);
    }





#if UNITY_EDITOR
    //调试方法----------------------------
    [Header("时间拉伸系数")]
    [SerializeField]
    [Range(0, 1)]
    [ContextMenuItem("应用","TimeScaleDebug")]
    private float timeScaleDebug = 1.0f;

    private void TimeScaleDebug()
    {
        SetTimeScale(timeScaleDebug);
    }
#endif
}
