using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 菜单系统
/// </summary>
[DisallowMultipleComponent]
public class MenuSystem : MonoBehaviour
{
#if UNITY_EDITOR
    [Header("【菜单系统】")]
    public EmptyStruct 一一一一一一一一一一一一一一一一一一一一一一一一一一一;
#endif
    [System.Serializable]
    public class Setting
    {
        //参数--------------------------------






        //属性--------------------------------
        /// <summary>
        /// 游戏菜单父物体
        /// </summary>
        private GameObject menuParent
        {
            get
            {
                if (menuParentInstance == null)
                {
                    menuParentInstance = GameSystemRunningInstance.instance.transform.GetChild(0).gameObject;
                }
                return menuParentInstance;
            }
        }
        private GameObject menuParentInstance;

        /// <summary>
        /// 菜单是否已经打开
        /// </summary>
        private bool isOpen = false;






        //方法--------------------------------
        /// <summary>
        /// 打开/关闭菜单
        /// </summary>
        public void TurnMenu()
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

        /// <summary>
        /// 打开菜单
        /// </summary>
        private void OpenMenu()
        {
            menuParent.SetActive(true);
        }

        /// <summary>
        /// 关闭菜单
        /// </summary>
        private void CloseMenu()
        {
            menuParent.SetActive(false);
        }
    }
    public Setting setting;
}
