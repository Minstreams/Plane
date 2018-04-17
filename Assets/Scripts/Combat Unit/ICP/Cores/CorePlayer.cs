using System.Collections;
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

        if (Input.GetMouseButtonDown(0))
        {
            theICP.LaunchPrimaryWeapon();
        }
        if (Input.GetMouseButtonDown(1))
        {
            theICP.LaunchSecondaryWeapon();
        }
        if (Input.GetMouseButtonUp(0))
        {
            theICP.StopLaunchPrimaryWeapon();
        }
        if (Input.GetMouseButtonUp(1))
        {
            theICP.StopLaunchSecondaryWeapon();
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        theICP.Move(h, v);
    }
}
