using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 简单追踪
/// </summary>
[AddComponentMenu("My Assets/Simple Tracker")]
[DisallowMultipleComponent]
public class SimpleTracker : MonoBehaviour
{
    [Header("【简单追踪器】")]
    public Transform target;

    private void Update()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}
