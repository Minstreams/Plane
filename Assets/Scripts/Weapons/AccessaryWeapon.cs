using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AccessaryWeapon : MonoBehaviour
{
    //通用部署代码-----------------------
    [Header("左炮管")]
    [SerializeField]
    private Transform LPart;
    [Header("右炮管")]
    [SerializeField]
    private Transform RPart;

    /// <summary>
    /// 调整副武器位置
    /// </summary>
    /// <param name="positionL">副武器接口位置1</param>
    /// <param name="positionR">副武器接口位置2</param>
	public void SetPosition(Transform positionL, Transform positionR)
    {
        LPart.SetParent(positionL,false);
        LPart.localPosition = Vector3.zero;
        LPart.localRotation = Quaternion.identity;
        RPart.SetParent(positionR, false);
        RPart.localPosition = Vector3.zero;
        RPart.localRotation = Quaternion.identity;
    }



    //控制方法--------------------------
    /// <summary>
    /// 转动视角
    /// </summary>
    /// <param name="horizontalQuaternion">水平四元数</param>
    /// <param name="verticalQuaternion">垂直四元数</param>
    public abstract void Rotate(Quaternion horizontalQuaternion, Quaternion verticalQuaternion);

}
