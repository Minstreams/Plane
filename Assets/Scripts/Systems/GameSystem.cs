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
    /// <summary>
    /// 自身实例(这样写保证编辑器模式下也能调用)
    /// </summary>
    public static GameSystem system
    {
        get
        {
            if (system == null)
            {
                system = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<GameSystem>();
            }
            return system;
        }
        private set
        {
            system = value;
        }
    }

    /// <summary>
    /// 流程控制系统
    /// </summary>
    public static RunningSystem runningSystem
    {
        get
        {
            if (runningSystem == null)
            {
                runningSystem = system.GetComponent<RunningSystem>();
            }
            return runningSystem;
        }
        private set
        {
            runningSystem = value;
        }
    }

    /// <summary>
    /// 声音系统
    /// </summary>
    public static AudioSystem audioSystem
    {
        get
        {
            if (audioSystem == null)
            {
                audioSystem = system.GetComponent<AudioSystem>();
            }
            return audioSystem;
        }
        private set
        {
            audioSystem = value;
        }
    }

    /// <summary>
    /// 场景管理系统
    /// </summary>
    public static SceneSystem sceneSystem
    {
        get
        {
            if (sceneSystem == null)
            {
                sceneSystem = system.GetComponent<SceneSystem>();
            }
            return sceneSystem;
        }
        private set
        {
            sceneSystem = value;
        }
    }

    /// <summary>
    /// 子弹时间系统
    /// </summary>
    public static BulletTimeSystem bulletTimeSystem
    {
        get
        {
            if (bulletTimeSystem == null)
            {
                bulletTimeSystem = system.GetComponent<BulletTimeSystem>();
            }
            return bulletTimeSystem;
        }
        private set
        {
            bulletTimeSystem = value;
        }
    }

    /// <summary>
    /// 菜单系统
    /// </summary>
    public static MenuSystem menuSystem
    {
        get
        {
            if (menuSystem == null)
            {
                menuSystem = system.GetComponent<MenuSystem>();
            }
            return menuSystem;
        }
        private set
        {
            menuSystem = value;
        }
    }

    /// <summary>
    /// 武器系统
    /// </summary>
    public static WeaponSystem weaponSystem
    {
        get
        {
            if (weaponSystem == null)
            {
                weaponSystem = system.GetComponent<WeaponSystem>();
            }
            return weaponSystem;
        }
        private set
        {
            weaponSystem = value;
        }
    }

    //方法--------------------------------
    private void Start()
    {
        runningSystem.StartRunning();
    }
}
