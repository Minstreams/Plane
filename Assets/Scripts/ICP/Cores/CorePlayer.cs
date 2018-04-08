﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家控制的核心
/// </summary>
[AddComponentMenu("Core/Player")]
public class CorePlayer : Core
{
    [Header("玩家控制的核心")]
    [SerializeField]
    [Range(0.5f, 3)]
    private float horizontalSensitivity = 1;
    [SerializeField]
    [Range(0.5f, 3)]
    private float verticalSensitivity = 1;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSensitivity;

        theICP.RotateAngle(mouseX, mouseY);
    }
}
