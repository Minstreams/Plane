using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家控制的核心
/// </summary>
[AddComponentMenu("Core/Player")]
public class CorePlayer : Core
{
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        theICP.RotateAngle(mouseX, mouseY);
    }
}
