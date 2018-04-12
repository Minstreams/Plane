using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战争系统，用于部队统计，阵营分配，仇恨计算
/// </summary>
[DisallowMultipleComponent]
public class WarSystem : MonoBehaviour
{
#if UNITY_EDITOR
    [Header("【战争系统（部队统计，阵营分配，仇恨计算）】")]
    public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
    [System.Serializable]
    public class Setting
    {
        //参数--------------------------------




        //属性--------------------------------


        //方法--------------------------------

    }
    public Setting setting;

    /// <summary>
    /// 阵营
    /// </summary>
    public enum Camp
    {
        Human,
        Stromare
    }
}
