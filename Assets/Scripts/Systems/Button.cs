using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有按钮的父类
/// </summary>
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SpriteRenderer))]
[DisallowMultipleComponent]
public abstract class Button : StateBehaviour
{
    //属性--------------------------------
    [Header("【按钮组件】")]
    [Header("按钮图片：")]
    [SerializeField]
    private Sprite spriteUp;
    [SerializeField]
    private Sprite spriteDown;
    [SerializeField]
    private Sprite spriteOver;


    //方法--------------------------------
    /// <summary>
    /// 检查状态时被调用
    /// </summary>
    /// <param name="result">检查结果激活与否</param>
    protected sealed override void OnCheck(bool result)
    {
        gameObject.SetActive(result);
    }

    protected override void Start()
    {
        base.Start();

        //检测
        if(spriteDown == null || spriteOver == null || spriteUp == null)
        {
            Debug.LogError(gameObject + "的Sprite没有赋值！");
            return;
        }


        GetComponent<SpriteRenderer>().sprite = spriteUp;
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = spriteOver;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().sprite = spriteDown;
            OnBottonDown();
        }

        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<SpriteRenderer>().sprite = spriteOver;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = spriteUp;
    }

    /// <summary>
    /// 按钮按下时调用
    /// </summary>
    protected abstract void OnBottonDown();

    /// <summary>
    /// 设置完毕
    /// </summary>
    [ContextMenu("设置完毕")]
    private void SetUpOver()
    {
        GetComponent<SpriteRenderer>().sprite = spriteUp;
    }
}
