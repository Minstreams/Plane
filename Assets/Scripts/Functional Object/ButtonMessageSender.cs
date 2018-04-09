using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Function/Botton Message Sender")]
public class ButtonMessageSender : Button
{
    [Header("请选择按钮功能")]
    [SerializeField]
    private GameSystemRunningInstance.ButtonMessage message;

    protected override void OnBottonDown()
    {
        GameSystemRunningInstance.instance.SendButtonMessage(message);
    }
}
