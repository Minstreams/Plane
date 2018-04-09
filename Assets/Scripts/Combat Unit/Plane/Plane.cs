using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌机
/// </summary>
public class Plane : MonoBehaviour {
    //不要求碰撞箱组件
    //为了性能考虑，避免使用MeshCollider

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
