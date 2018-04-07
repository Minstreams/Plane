using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MainWeapon/Test1")]
public class MainWeaponTest1 : MainWeapon
{
    public Transform hBody;
    public Transform vBody;

    protected override void Launch()
    {
        throw new NotImplementedException();
    }

    protected override void Rotate(Quaternion hRotation, Quaternion vRotation)
    {
        hBody.rotation = hRotation;
        vBody.localRotation = vRotation;
    }
}
