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
    public class Parameters : GameSystem.WeaponSystem.ParametersData
    {

    }

    private Parameters parameters { get { return GameSystem.WeaponSystem.Setting.mainWeaponList.test1; } }
    protected override RotateParameters rotateParameters { get { return parameters.rotateParameters; } }





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
