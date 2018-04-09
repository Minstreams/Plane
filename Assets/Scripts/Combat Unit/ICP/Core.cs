using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 核心
/// </summary>
[DisallowMultipleComponent]
[RequireComponent(typeof(ICP))]
public abstract class Core : MonoBehaviour
{
    private ICP icp;
    protected ICP theICP
    {
        get
        {
            if (icp == null)
            {
                icp = GetComponent<ICP>();
            }
            return icp;
        }
    }

}
