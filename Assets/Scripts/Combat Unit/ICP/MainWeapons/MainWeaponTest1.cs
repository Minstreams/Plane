using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主武器Teste1
/// </summary>
[AddComponentMenu("MainWeapon/Test1")]
public class MainWeaponTest1 : MainWeapon
{
    //参数----------------------------------
    [System.Serializable]
    public struct OtherParameters
    {

    }

    private OtherParameters parameters { get { return GameSystem.weaponSystem.setting.mainWeaponList.test1.otherParameters; } }
    protected override RotateParameters rotateParameters { get { return GameSystem.weaponSystem.setting.mainWeaponList.test1.rotateParameters; } }





    //结构----------------------------------
    public Transform hBody;
    public Transform vBody;





    //实现----------------------------------
    public override void Launch()
    {
        throw new NotImplementedException();
    }

    protected override void Rotate(Quaternion hRotation, Quaternion vRotation)
    {
        hBody.rotation = hRotation;
        vBody.localRotation = vRotation;
    }
}
