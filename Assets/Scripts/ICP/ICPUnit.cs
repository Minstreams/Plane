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
    [Header("【通用参数】")]
    [SerializeField]
    [Header("水平角速度上限（度/秒）：")]
    private float horizontalAngleSpeedLimit = 30;
    [SerializeField]
    [Header("垂直角速度上限（度/秒）：")]
    private float verticalAngleSpeedLimit = 30;
    [SerializeField]
    [Header("水平旋转平滑度:")]
    [Range(0, 0.95f)]
    private float horizontalSmoothnessRate = 0.4f;
    [SerializeField]
    [Header("垂直旋转平滑度:")]
    [Range(0, 0.95f)]
    private float verticalSmoothnessRate = 0.4f;


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
        hAngle +=
            Mathf.Clamp(
            (hTargetAngle - hAngle) * (1 - horizontalSmoothnessRate),
            -horizontalAngleSpeedLimit * BulletTimeSystem.BulletUpdateTimeInterVal,
            horizontalAngleSpeedLimit * BulletTimeSystem.BulletUpdateTimeInterVal
            );
        vAngle +=
            Mathf.Clamp(
                (vTargetAngle - vAngle) * (1 - verticalSmoothnessRate),
                -verticalAngleSpeedLimit * BulletTimeSystem.BulletUpdateTimeInterVal,
                verticalAngleSpeedLimit * BulletTimeSystem.BulletUpdateTimeInterVal
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
