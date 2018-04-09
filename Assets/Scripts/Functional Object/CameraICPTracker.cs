using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///ICP摄像机
/// </summary>
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Function/ICP Camera")]
public class CameraICPTracker : MonoBehaviour
{
    [Header("【ICP摄像机】")]
    public ICP target;

    void BeforeLoad()
    {
        transform.SetParent(null);
    }

    void AfterLoad()
    {
        transform.SetParent(target.corePosition);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    private void Awake()
    {
        target.BeforeLoad += BeforeLoad;
        target.AfterLoad += AfterLoad;
        AfterLoad();
    }
}
