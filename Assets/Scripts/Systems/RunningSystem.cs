using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 流程控制系统
/// </summary>
[DisallowMultipleComponent]
public class RunningSystem : MonoBehaviour
{
    //参数--------------------------------
    [System.Serializable]
    public struct Setting
    {

    }
    [Header("【流程控制系统】")]
    [Header("参数设置：")]
    public Setting setting;




    //属性--------------------------------
    /// <summary>
    /// 按钮信息枚举
    /// </summary>
    public enum ButtonMessage
    {
        Start,
        Exit
    }

    private bool[] buttonMessageReciver;





    //方法--------------------------------
    /// <summary>
    /// 游戏启动
    /// </summary>
    public void StartRunning()
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

    private void Awake()
    {
        //不初始化具体元素，默认数组元素为False
        buttonMessageReciver = new bool[System.Enum.GetValues(typeof(ButtonMessage)).Length];
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
