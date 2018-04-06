using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏系统
/// </summary>
[DisallowMultipleComponent]

[RequireComponent(typeof(RunningSystem))]
[RequireComponent(typeof(AudioSystem))]
[RequireComponent(typeof(StateSystem))]
[RequireComponent(typeof(SceneSystem))]
[RequireComponent(typeof(MenuSystem))]
public class GameSystem : MonoBehaviour
{
    //参数属性----------------------------
    [System.Serializable]
    public struct Setting
    {

    }

    [Header("【游戏系统】")]
    [Header("参数设置：")]
    public Setting setting;



    //系统实例----------------------------
    /// <summary>
    /// 自身实例
    /// </summary>
    public static GameSystem system = null;

    /// <summary>
    /// 流程控制系统
    /// </summary>
    public static RunningSystem runningSystem { get { return system.GetComponent<RunningSystem>(); } }

    /// <summary>
    /// 声音系统
    /// </summary>
    public static AudioSystem audioSystem { get { return system.GetComponent<AudioSystem>(); } }
   
    /// <summary>
    /// 状态系统
    /// </summary>
    public static StateSystem stateSystem { get { return system.GetComponent<StateSystem>(); } }

    /// <summary>
    /// 场景管理系统
    /// </summary>
    public static SceneSystem sceneSystem { get { return system.GetComponent<SceneSystem>(); } }

    /// <summary>
    /// 菜单系统
    /// </summary>
    public static MenuSystem menuSystem { get { return system.GetComponent<MenuSystem>(); } }




    //方法--------------------------------
    private void Awake()
    {
        if (system != null)
        {
            Debug.LogError("不允许出现多个GameSystem！");
        }
        system = this;
    }

    private void Start()
    {
        runningSystem.StartRunning();
    }
}
