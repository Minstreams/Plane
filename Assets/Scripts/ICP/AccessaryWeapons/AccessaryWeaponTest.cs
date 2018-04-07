using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("AccessaryWeapon/Test")]
public class AccessaryWeaponTest : AccessaryWeapon
{
    public Transform bodyL;
    public Transform bodyR;

    protected override void Launch()
    {
        throw new NotImplementedException();
    }

    protected override void Rotate(Quaternion hRotation, Quaternion vRotation)
    {
        Quaternion rotation = hRotation * vRotation;

        bodyL.rotation = rotation;
        bodyR.rotation = rotation;
    }
}
