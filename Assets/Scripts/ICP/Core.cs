using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 核心
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(ICP))]
public class Core : MonoBehaviour
{
    protected ICP theICP { get { return GetComponent<ICP>(); } }

}
