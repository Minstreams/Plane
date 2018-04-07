using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("WeaponBottom/Test")]
public class WeaponBottomTest : WeaponBottom
{
    public Transform body;

    public override void LaunchMode(bool state)
    {
        throw new NotImplementedException();
    }

    public override void Move(float h, float v)
    {
        throw new NotImplementedException();
    }

    protected override void Rotate(Quaternion hRotation, Quaternion vRotation)
    {
        body.localRotation = hRotation;
    }
}
