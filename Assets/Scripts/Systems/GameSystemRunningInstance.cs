using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏系统流程管理实例
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSystem))]
[RequireComponent(typeof(SceneSystem))]
[RequireComponent(typeof(BulletTimeSystem))]
[RequireComponent(typeof(MenuSystem))]
[RequireComponent(typeof(WeaponSystem))]
[RequireComponent(typeof(WarSystem))]
public class GameSystemRunningInstance : MonoBehaviour
{
#if UNITY_EDITOR
    [Header("【游戏系统】")]
    public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
    private void Reset()
    {
        gameObject.tag = "GameSystem";
    }
#endif



    //属性--------------------------------
    /// <summary>
    /// 自身实例(这样写保证编辑器模式下也能调用)
    /// </summary>
    public static GameSystemRunningInstance instance
    {
        get
        {
            if (gameSystemInstance == null)
            {
                gameSystemInstance = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<GameSystemRunningInstance>();
            }
            return gameSystemInstance;
        }
    }
    private static GameSystemRunningInstance gameSystemInstance;

    /// <summary>
    /// 按钮信息枚举
    /// </summary>
    public enum ButtonMessage
    {
        Start,
        Exit
    }
    /// <summary>
    /// 记录按钮信息
    /// </summary>
    private bool[] buttonMessageReciver = new bool[System.Enum.GetValues(typeof(ButtonMessage)).Length];





    //方法--------------------------------
    /// <summary>
    /// 游戏启动
    /// </summary>
    private void Start()
    {
        StartCoroutine(start());
    }
    /// <summary>
    /// 检查按钮信息，收到则返回true
    /// </summary>
    /// <param name="message">要检查的信息</param>
    /// <returns>检查按钮信息，收到则返回true</returns>
    private bool GetButtonMessage(ButtonMessage message)
    {
        if (buttonMessageReciver[(int)message])
        {
            buttonMessageReciver[(int)message] = false;
            return true;
        }
        return false;
    }
    /// <summary>
    /// 发送按钮信息
    /// </summary>
    /// <param name="message">信息</param>
    public void SendButtonMessage(ButtonMessage message)
    {
        buttonMessageReciver[(int)message] = true;
    }
    /// <summary>
    /// 重置
    /// </summary>
    private void ResetButtonMessage()
    {
        buttonMessageReciver.Initialize();
    }



    //流程--------------------------------
    private IEnumerator start()
    {
        StartCoroutine(exitCheck());

        //开始场景-------------------------------------
        GameSystem.sceneSystem.LoadScene("StartScene");

        while (true)
        {
            if (GetButtonMessage(ButtonMessage.Start))
            {
                print("Start Down");
                break;
            }
            yield return 0;
        }

        ResetButtonMessage();


        //游戏场景-------------------------------------
        GameSystem.sceneSystem.LoadScene("Game0");

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameSystem.menuSystem.TurnMenu();
            }
            yield return 0;
        }

        ResetButtonMessage();
    }

    private IEnumerator exitCheck()
    {
        while (true)
        {
            if (GetButtonMessage(ButtonMessage.Exit))
            {
                print("游戏已经结束了！按啥都没用了！");
                Application.Quit();
                StopAllCoroutines();
            }
            yield return 0;
        }
    }
}

#if UNITY_EDITOR
[System.Serializable]
public struct EmptyStruct { }
#endif


/// <summary>
/// 游戏系统
/// </summary>
public class GameSystem
{
    //系统实例----------------------------
    /// <summary>
    /// 声音系统
    /// </summary>
    public static AudioSystem.Setting audioSystem
    {
        get
        {
            if (audioSystemInstance == null)
            {
                audioSystemInstance = GameSystemRunningInstance.instance.GetComponent<AudioSystem>().setting;
            }
            return audioSystemInstance;
        }
    }
    private static AudioSystem.Setting audioSystemInstance;

    /// <summary>
    /// 场景管理系统
    /// </summary>
    public static SceneSystem.Setting sceneSystem
    {
        get
        {
            if (sceneSystemInstance == null)
            {
                sceneSystemInstance = GameSystemRunningInstance.instance.GetComponent<SceneSystem>().setting;
            }
            return sceneSystemInstance;
        }
    }
    private static SceneSystem.Setting sceneSystemInstance;

    /// <summary>
    /// 子弹时间系统
    /// </summary>
    public static BulletTimeSystem.Setting bulletTimeSystem
    {
        get
        {
            if (bulletTimeSystemInstance == null)
            {
                bulletTimeSystemInstance = GameSystemRunningInstance.instance.GetComponent<BulletTimeSystem>().setting;
            }
            return bulletTimeSystemInstance;
        }
    }
    private static BulletTimeSystem.Setting bulletTimeSystemInstance;

    /// <summary>
    /// 菜单系统
    /// </summary>
    public static MenuSystem.Setting menuSystem
    {
        get
        {
            if (menuSystemInstance == null)
            {
                menuSystemInstance = GameSystemRunningInstance.instance.GetComponent<MenuSystem>().setting;
            }
            return menuSystemInstance;
        }
    }
    private static MenuSystem.Setting menuSystemInstance;

    /// <summary>
    /// 武器系统
    /// </summary>
    public static WeaponSystem.Setting weaponSystem
    {
        get
        {
            if (weaponSystemInstance == null)
            {
                weaponSystemInstance = GameSystemRunningInstance.instance.GetComponent<WeaponSystem>().setting;
            }
            return weaponSystemInstance;
        }
    }
    private static WeaponSystem.Setting weaponSystemInstance;

    /// <summary>
    /// 战争系统
    /// </summary>
    public static WarSystem.Setting warSystem
    {
        get
        {
            if (warSystemInstance == null)
            {
                warSystemInstance = GameSystemRunningInstance.instance.GetComponent<WarSystem>().setting;
            }
            return warSystemInstance;
        }
    }
    private static WarSystem.Setting warSystemInstance;
}