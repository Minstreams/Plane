using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 武器父类
/// </summary>
public abstract class Weapon : ICPUnit
{
    /// <summary>
    /// 开炮
    /// </summary>
    protected abstract void Launch();
}
