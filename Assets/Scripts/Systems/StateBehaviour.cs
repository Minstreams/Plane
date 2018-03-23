using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 封装的Behaviour
/// </summary>
public class StateBehaviour : MonoBehaviour
{
    /// <summary>
    /// 激活状态
    /// </summary>
    [Header("激活状态：")]
    [SerializeField]
    private StateSystem.GameState activeState;

    [ContextMenu("StateCheck")]
    /// <summary>
    /// 检查状态并自我激活/取消激活
    /// </summary>
    private void StateCheck()
    {
        if (this.enabled != (GameSystem.stateSystem.gameState == activeState))
        {
            OnCheck(!this.enabled);
            this.enabled = !this.enabled;
        }
        print("checked");
    }

    /// <summary>
    /// 检查状态时被调用
    /// </summary>
    /// <param name="result">检查结果激活与否</param>
    /// <returns></returns>
    protected virtual void OnCheck(bool result)
    {

    }

    protected virtual void Start()
    {
        StateCheck();
    }
}
