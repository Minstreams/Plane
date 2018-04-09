using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 子弹时间系统
/// </summary>
[DisallowMultipleComponent]
public class BulletTimeSystem : MonoBehaviour
{
#if UNITY_EDITOR
    [Header("【子弹时间系统】")]
    public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
    [System.Serializable]
    public class Setting
    {
        //参数--------------------------------




    }
    public Setting setting;


    //静态属性--------------------------------
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


    /// <summary>
    /// 修改时间拉伸系数
    /// </summary>
    /// <param name="scale">系数(Clamped to 0-1)</param>
    public static void SetTimeScale(float scale)
    {
        //暂时
        timeScale = Mathf.Clamp01(scale);
    }

#if UNITY_EDITOR
    //调试方法----------------------------
    [Header("时间拉伸系数")]
    [SerializeField]
    [Range(0, 1)]
    private float timeScaleDebug = 1.0f;

    private void Update()
    {
        SetTimeScale(timeScaleDebug);
    }
#endif
}
