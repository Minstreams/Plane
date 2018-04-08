using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ICP安装单位
/// </summary>
[DisallowMultipleComponent]
public abstract class ICPUnit : BulletTimeBehaviour
{
    //参数---------------------------------------------


    /// <summary>
    /// 通用参数
    /// </summary>
    [System.Serializable]
    public struct RotateParameters
    {
        [Header("【通用参数】")]
        [Header("水平角速度上限（度/秒）：")]
        public float horizontalAngleSpeedLimit;
        [Header("垂直角速度上限（度/秒）：")]
        public float verticalAngleSpeedLimit;
        [Header("水平旋转平滑度:")]
        [Range(0, 0.95f)]
        public float horizontalSmoothnessRate;
        [Header("垂直旋转平滑度:")]
        [Range(0, 0.95f)]
        public float verticalSmoothnessRate;
    }

    /// <summary>
    /// 视角旋转参数
    /// </summary>
    protected abstract RotateParameters rotateParameters { get; }


    private float hAngle = 0;
    private float vAngle = 0;

    private float hSpeed;
    private float vSpeed;

    private float hOutputAngle;
    private float vOutputAngle;

    //通用控制方法-------------------------------------
    /// <summary>
    /// 转动视角
    /// </summary>
    /// <param name="h">水平分量</param>
    /// <param name="v">垂直分量</param>
    public void RotateAngle(float hTargetAngle, float vTargetAngle)
    {
        hSpeed = Mathf.Clamp(
            (hTargetAngle - hAngle) * (1 - rotateParameters.horizontalSmoothnessRate) * BulletTimeSystem.OneDividedBulletUpdateTimeInterVal,
            -rotateParameters.horizontalAngleSpeedLimit,
            rotateParameters.horizontalAngleSpeedLimit
            );
        vSpeed = Mathf.Clamp(
                (vTargetAngle - vAngle) * (1 - rotateParameters.verticalSmoothnessRate) * BulletTimeSystem.OneDividedBulletUpdateTimeInterVal,
                -rotateParameters.verticalAngleSpeedLimit,
                rotateParameters.verticalAngleSpeedLimit
                );

        hAngle += hSpeed * BulletTimeSystem.BulletUpdateTimeInterVal;
        vAngle += vSpeed * BulletTimeSystem.BulletUpdateTimeInterVal;

        hOutputAngle = hAngle;
        vOutputAngle = vAngle;
    }

    protected override void Update()
    {
        Rotate(
            new Quaternion(0, Mathf.Sin(hOutputAngle * Mathf.PI / 360.0f), 0, Mathf.Cos(hOutputAngle * Mathf.PI / 360.0f)),
            new Quaternion(-Mathf.Sin(vOutputAngle * Mathf.PI / 360.0f), 0, 0, Mathf.Cos(vOutputAngle * Mathf.PI / 360.0f))
            );
        hOutputAngle += hSpeed * DeltaTime;
        vOutputAngle += vSpeed * DeltaTime;
    }

    /// <summary>
    /// 旋转
    /// </summary>
    /// <param name="hRotation">水平旋转四元数</param>
    /// <param name="vRotation">垂直旋转四元数</param>
    protected abstract void Rotate(Quaternion hRotation, Quaternion vRotation);
}
