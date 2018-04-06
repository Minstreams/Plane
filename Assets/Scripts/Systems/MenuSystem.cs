using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 菜单系统
/// </summary>
[DisallowMultipleComponent]
public class MenuSystem : MonoBehaviour
{
    //参数--------------------------------
    [System.Serializable]
    public struct Setting
    {

    }
    [Header("【菜单系统】")]
    [Header("参数设置：")]
    public Setting setting;

    //属性--------------------------------
    /// <summary>
    /// 游戏菜单副物体
    /// </summary>
    private GameObject menuParent;

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

    private void Awake()
    {
        menuParent = transform.GetChild(0).gameObject;
    }
}
