using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Function/Botton Message Sender")]
public class ButtonMessageSender : Button
{
    [Header("请选择按钮功能")]
    [SerializeField]
    private GameSystemInstance.GameSystemInstance.ButtonMessage message;

    protected override void OnBottonDown()
    {
        GameSystemInstance.GameSystemInstance.instance.SendButtonMessage(message);
    }
}
