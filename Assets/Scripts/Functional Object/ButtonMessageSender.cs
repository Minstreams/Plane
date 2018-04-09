using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Function/Botton Message Sender")]
public class ButtonMessageSender : Button
{
    [Header("请选择按钮功能")]
    [SerializeField]
    private RunningSystem.ButtonMessage message;

    protected override void OnBottonDown()
    {
        GameSystem.runningSystem.SendButtonMessage(message);
    }
}
