using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    /// <summary>
    /// 游戏系统流程管理实例
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSystemInstance))]
    [RequireComponent(typeof(SceneSystemInstance))]
    [RequireComponent(typeof(BulletTimeSystemInstance))]
    [RequireComponent(typeof(MenuSystemInstance))]
    [RequireComponent(typeof(WeaponSystemInstance))]
    [RequireComponent(typeof(WarSystemInstance))]
    public class GameSystemInstance : MonoBehaviour
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
        public static GameSystemInstance instance
        {
            get
            {
                if (gameSystemInstance == null)
                {
                    gameSystemInstance = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<GameSystemInstance>();
                }
                return gameSystemInstance;
            }
        }
        private static GameSystemInstance gameSystemInstance;

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
            GameSystem.SceneSystem.LoadScene("StartScene");

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
            GameSystem.SceneSystem.LoadScene("Game0");

            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameSystem.MenuSystem.TurnMenu();
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
}

#if UNITY_EDITOR
[System.Serializable]
public struct EmptyStruct { }
#endif
