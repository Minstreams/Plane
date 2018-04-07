using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MainWeapon/Test1")]
public class MainWeaponTest1 : MainWeapon
{
    public override void Rotate(Quaternion horizontalQuaternion, Quaternion verticalQuaternion)
    {
        throw new NotImplementedException();
    }
}
