using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ICP安装单位
/// </summary>
[DisallowMultipleComponent]
public abstract class ICPUnit : MonoBehaviour
{
    //参数---------------------------------------------
    /// <summary>
    /// 视角旋转参数
    /// </summary>
    [System.Serializable]
    public class RotateParameters
    {
        [Header("水平角速度上限（度/秒）：")]
        public float horizontalAngleSpeedLimit = 90;
        [Header("垂直角速度上限（度/秒）：")]
        public float verticalAngleSpeedLimit = 90;
        [Header("水平旋转平滑度:")]
        public bool horizontalSmooth = false;
        [Range(0.1f, 0.97f)]
        public float horizontalSmoothnessRate = 0.3f;
        [Header("垂直旋转平滑度:")]
        public bool verticalSmooth = false;
        [Range(0.1f, 0.97f)]
        public float verticalSmoothnessRate = 0.3f;
        [Header("上仰角限制"), Range(10, 90)]
        public float upAngleLimit = 90;
        [Header("下俯角限制"), Range(10, 90)]
        public float downAngleLimit = 30;

    }

    /// <summary>
    /// 视角旋转参数
    /// </summary>
    protected abstract RotateParameters rotateParameters { get; }

    private float hAngle = 0;
    private float vAngle = 0;

    //通用控制方法-------------------------------------
    /// <summary>
    /// 转动视角
    /// </summary>
    /// <param name="h">水平分量</param>
    /// <param name="v">垂直分量</param>
    public void RotateAngle(float hTargetAngle, float vTargetAngle)
    {
        //用角速度限制和角度限制进行Clamp裁剪
        hAngle += Mathf.Clamp
                (
                    (hTargetAngle - hAngle) *
                    (
                        rotateParameters.horizontalSmooth ?
                        (1 - Mathf.Pow(rotateParameters.horizontalSmoothnessRate, Time.deltaTime * GameSystem.BulletTimeSystem.TimeScale * GameSystem.BulletTimeSystem.OneDividedBulletUpdateTimeInterVal)) :
                        1
                    )
                    / Time.deltaTime / GameSystem.BulletTimeSystem.TimeScale,
                    -rotateParameters.horizontalAngleSpeedLimit,
                    rotateParameters.horizontalAngleSpeedLimit
                )
                * Time.deltaTime;

        vAngle = Mathf.Clamp
                (
                    vAngle +
                        Mathf.Clamp
                        (
                            (vTargetAngle - vAngle) *
                            (
                                rotateParameters.verticalSmooth ?
                                (1 - Mathf.Pow(rotateParameters.verticalSmoothnessRate, Time.deltaTime * GameSystem.BulletTimeSystem.TimeScale * GameSystem.BulletTimeSystem.OneDividedBulletUpdateTimeInterVal))
                                : 1
                            )
                            / Time.deltaTime / GameSystem.BulletTimeSystem.TimeScale,
                            -rotateParameters.verticalAngleSpeedLimit,
                            rotateParameters.verticalAngleSpeedLimit
                        )
                        * Time.deltaTime,
                    -rotateParameters.downAngleLimit, rotateParameters.upAngleLimit
                );

        Rotate(
            new Quaternion(0, Mathf.Sin(hAngle * Mathf.PI / 360.0f), 0, Mathf.Cos(hAngle * Mathf.PI / 360.0f)),
            new Quaternion(-Mathf.Sin(vAngle * Mathf.PI / 360.0f), 0, 0, Mathf.Cos(vAngle * Mathf.PI / 360.0f))
            );

    }

    /// <summary>
    /// 旋转
    /// </summary>
    /// <param name="hRotation">水平旋转四元数</param>
    /// <param name="vRotation">垂直旋转四元数</param>
    protected abstract void Rotate(Quaternion hRotation, Quaternion vRotation);
}
