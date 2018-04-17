﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    /// <summary>
    /// 游戏系统流程管理实例
    /// </summary>
    [AddComponentMenu("Components/Game System")]
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
        //编辑器模式下，全局查重，防止有多个游戏系统
        private static GameSystemInstance instance = null;
        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("不允许有多个游戏系统！");
            }
            instance = this;
        }
#endif
        //游戏启动----------------------------
        private void Start()
        {
            StartCoroutine(start());
        }


        //流程--------------------------------
        private IEnumerator start()
        {
            StartCoroutine(exitCheck());

            //开始场景-------------------------------------
            GameSystem.SceneSystem.LoadScene("StartScene");

            while (true)
            {
                if (GameSystem.MenuSystem.GetButtonMessage(GameSystem.MenuSystem.ButtonMessage.Start))
                {
                    print("Start Down");
                    break;
                }
                yield return 0;
            }

            GameSystem.MenuSystem.ResetButtonMessage();


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

            GameSystem.MenuSystem.ResetButtonMessage();
        }
        private IEnumerator exitCheck()
        {
            while (true)
            {
                if (GameSystem.MenuSystem.GetButtonMessage(GameSystem.MenuSystem.ButtonMessage.Exit))
                {
                    print("游戏已经结束了！按啥都没用了！");
                    Application.Quit();
                    StopAllCoroutines();
                }
                yield return 0;
            }
        }
    }

    /// <summary>
    /// 游戏子系统父类
    /// </summary>
    /// <typeparam name="InstanceClass"></typeparam>
    public class SystemInstance<InstanceClass> : MonoBehaviour
    {
        private static InstanceClass instance;
        /// <summary>
        /// 实例
        /// </summary>
        public static InstanceClass Instance
        {
            get
            {
                if (instance == null) instance = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<InstanceClass>();
                return instance;
            }
        }
    }
}

#if UNITY_EDITOR
[System.Serializable]
public struct EmptyStruct { }
#endif
