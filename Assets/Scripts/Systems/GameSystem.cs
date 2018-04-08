using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏系统
/// </summary>
[DisallowMultipleComponent]

[RequireComponent(typeof(RunningSystem))]
[RequireComponent(typeof(AudioSystem))]
[RequireComponent(typeof(SceneSystem))]
[RequireComponent(typeof(BulletTimeSystem))]
[RequireComponent(typeof(MenuSystem))]
[RequireComponent(typeof(WeaponSystem))]
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

    private void Reset()
    {
        gameObject.tag = "GameSystem";
    }


    //系统实例----------------------------
    private static GameSystem gameSystemInstance;
    private static RunningSystem runningSystemInstance;
    private static AudioSystem audioSystemInstance;
    private static SceneSystem sceneSystemInstance;
    private static BulletTimeSystem bulletTimeSystemInstance;
    private static MenuSystem menuSystemInstance;
    private static WeaponSystem weaponSystemInstance;


    /// <summary>
    /// 自身实例(这样写保证编辑器模式下也能调用)
    /// </summary>
    public static GameSystem system
    {
        get
        {
            if (gameSystemInstance == null)
            {
                gameSystemInstance = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<GameSystem>();
            }
            return gameSystemInstance;
        }
    }

    /// <summary>
    /// 流程控制系统
    /// </summary>
    public static RunningSystem runningSystem
    {
        get
        {
            if (runningSystemInstance == null)
            {
                runningSystemInstance = system.GetComponent<RunningSystem>();
            }
            return runningSystemInstance;
        }
    }

    /// <summary>
    /// 声音系统
    /// </summary>
    public static AudioSystem audioSystem
    {
        get
        {
            if (audioSystemInstance == null)
            {
                audioSystemInstance = system.GetComponent<AudioSystem>();
            }
            return audioSystemInstance;
        }
    }

    /// <summary>
    /// 场景管理系统
    /// </summary>
    public static SceneSystem sceneSystem
    {
        get
        {
            if (sceneSystemInstance == null)
            {
                sceneSystemInstance = system.GetComponent<SceneSystem>();
            }
            return sceneSystemInstance;
        }
    }

    /// <summary>
    /// 子弹时间系统
    /// </summary>
    public static BulletTimeSystem bulletTimeSystem
    {
        get
        {
            if (bulletTimeSystemInstance == null)
            {
                bulletTimeSystemInstance = system.GetComponent<BulletTimeSystem>();
            }
            return bulletTimeSystemInstance;
        }
    }

    /// <summary>
    /// 菜单系统
    /// </summary>
    public static MenuSystem menuSystem
    {
        get
        {
            if (menuSystemInstance == null)
            {
                menuSystemInstance = system.GetComponent<MenuSystem>();
            }
            return menuSystemInstance;
        }
    }
    
    /// <summary>
    /// 武器系统
    /// </summary>
    public static WeaponSystem weaponSystem
    {
        get
        {
            if (weaponSystemInstance == null)
            {
                weaponSystemInstance = system.GetComponent<WeaponSystem>();
            }
            return weaponSystemInstance;
        }
    }

    //方法--------------------------------
    private void Start()
    {
        runningSystem.StartRunning();
    }
}
