using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    /// <summary>
    /// 菜单系统
    /// </summary>
    [DisallowMultipleComponent]
    public class MenuSystemInstance : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("【菜单系统】")]
        public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
        [System.Serializable]
        public class Setting
        {
            /// <summary>
            /// 游戏菜单父物体
            /// </summary>
            [HideInInspector]
            public GameObject menuParent;
        }

        public Setting setting;
        private void Awake() { GameSystem.MenuSystem.Instance = this; }

        private void Reset() { setting.menuParent = transform.GetChild(0).gameObject; }
    }
}

namespace GameSystem
{
    /// <summary>
    /// 菜单系统
    /// </summary>
    public static class MenuSystem
    {
        /// <summary>
        /// 设置参数
        /// </summary>
        private static GameSystemInstance.MenuSystemInstance.Setting Setting { get { return Instance.setting; } }
        /// <summary>
        /// 实例
        /// </summary>
        public static GameSystemInstance.MenuSystemInstance Instance { private get; set; }



        //变量--------------------------------
        /// <summary>
        /// 菜单是否已经打开
        /// </summary>
        private static bool isOpen = false;



        //方法--------------------------------
        /// <summary>
        /// 打开/关闭菜单
        /// </summary>
        public static void TurnMenu()
        {
            if (isOpen)
            {
                CloseMenu();
                isOpen = false;
            }
            else
            {
                OpenMenu();
                isOpen = true;
            }
        }
        private static void OpenMenu()
        {
            Setting.menuParent.SetActive(true);
        }
        private static void CloseMenu()
        {
            Setting.menuParent.SetActive(false);
        }
    }
}