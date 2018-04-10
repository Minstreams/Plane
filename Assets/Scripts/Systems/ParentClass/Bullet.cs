using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹类
/// </summary>
[RequireComponent(typeof(SphereCollider))]
public class Bullet : MonoBehaviour {
    private void Reset()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }
}
