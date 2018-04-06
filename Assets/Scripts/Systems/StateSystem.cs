using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态系统（状态机）
/// </summary>
[DisallowMultipleComponent]
public class StateSystem : MonoBehaviour
{
    //参数--------------------------------
    [System.Serializable]
    public struct Setting
    {

    }
    [Header("【状态系统】")]
    [Header("参数设置：")]
    public Setting setting;



    //属性--------------------------------
    /// <summary>
    /// 游戏状态
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// 开始菜单状态
        /// </summary>
        StartMenu,
        Base,
        Outside
    }

    /// <summary>
    /// 记录游戏状态
    /// </summary>
    [SerializeField]
    [Header("当前游戏状态")]
    private GameState gamestate;

    /// <summary>
    /// 记录游戏状态(只读)
    /// </summary>
    public GameState gameState { get { return gamestate; } }



    //方法--------------------------------
    /// <summary>
    /// 用于状态检查的委托方法
    /// </summary>
    public System.Action stateCheck;

    public void ChangeStateTo(GameState state)
    {
        if (state == gamestate) return;

        gamestate = state;
        if (stateCheck != null) stateCheck();
    }

    [ContextMenu("TestCheck")]
    private void TestCheck()
    {
        if (stateCheck != null) stateCheck();
    }
}
