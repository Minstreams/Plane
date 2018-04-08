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
        [Range(0, 0.97f)]
        public float horizontalSmoothnessRate = 0.3f;
        [Header("垂直旋转平滑度:")]
        [Range(0, 0.97f)]
        public float verticalSmoothnessRate = 0.3f;
        [Range(10, 90)]
        [Header("上仰角限制")]
        public float upAngleLimit = 90;
        [SerializeField]
        [Range(10, 90)]
        [Header("下俯角限制")]
        public float downAngleLimit = 30;
    }

    /// <summary>
    /// 视角旋转参数
    /// </summary>
    protected abstract RotateParameters rotateParameters { get; }


    private float hAngle = 0;
    private float vAngle = 0;

    private float hDelta;
    private float vDelta;

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
        //用角速度限制和角度限制进行Clamp裁剪
        hAngle += Mathf.Clamp(
                    (hTargetAngle - hAngle) * (1 - rotateParameters.horizontalSmoothnessRate) * BulletTimeSystem.OneDividedBulletUpdateTimeInterVal,
                    -rotateParameters.horizontalAngleSpeedLimit,rotateParameters.horizontalAngleSpeedLimit
                ) 
                * BulletTimeSystem.BulletUpdateTimeInterVal;
                    
        vAngle = Mathf.Clamp(
                    vAngle +
                        Mathf.Clamp(
                            (vTargetAngle - vAngle) * (1 - rotateParameters.verticalSmoothnessRate) * BulletTimeSystem.OneDividedBulletUpdateTimeInterVal,
                             -rotateParameters.verticalAngleSpeedLimit,rotateParameters.verticalAngleSpeedLimit
                         ) 
                        * BulletTimeSystem.BulletUpdateTimeInterVal,
                    -rotateParameters.downAngleLimit,rotateParameters.upAngleLimit
                ); 

        //计算Delta量
        hDelta = hAngle - hOutputAngle;
        vDelta = vAngle - vOutputAngle;

    }

    public void FixedRotateAngle()
    {
        Rotate(
            new Quaternion(0, Mathf.Sin(hOutputAngle * Mathf.PI / 360.0f), 0, Mathf.Cos(hOutputAngle * Mathf.PI / 360.0f)),
            new Quaternion(-Mathf.Sin(vOutputAngle * Mathf.PI / 360.0f), 0, 0, Mathf.Cos(vOutputAngle * Mathf.PI / 360.0f))
            );

        hOutputAngle += hDelta * BulletTimeSystem.TimeScale;
        vOutputAngle += vDelta * BulletTimeSystem.TimeScale;

        if (hAngle - hOutputAngle > 0 == hDelta < 0)
        {
            hOutputAngle = hAngle;
        }
        if (vAngle - vOutputAngle > 0 == vDelta < 0)
        {
            vOutputAngle = vAngle;
        }
    }

    /// <summary>
    /// 旋转
    /// </summary>
    /// <param name="hRotation">水平旋转四元数</param>
    /// <param name="vRotation">垂直旋转四元数</param>
    protected abstract void Rotate(Quaternion hRotation, Quaternion vRotation);
}
