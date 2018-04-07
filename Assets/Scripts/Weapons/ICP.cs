using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 集成作战单元 Integrated Combat Platform
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("Combat Unit/ICP")]
public class ICP : MonoBehaviour
{
    //测试用？？-----------------------------------
    [SerializeField]
    private WeaponSystem.WeaponBottomEnum weaponBottomEnum;
    [SerializeField]
    private WeaponSystem.MainWeaponEnum mainWeaponEnum;
    [SerializeField]
    private WeaponSystem.AccessaryWeaponEnum accessaryWeaponEnum;

    //逻辑组成-------------------------------------
    private WeaponBottom weaponBottom;
    private MainWeapon mainWeapon;
    private AccessaryWeapon accessaryWeapon;

    //加载武器-------------------------------------
    /// <summary>
    /// 根据Enum的值加载武器
    /// </summary>
    [ContextMenu("加载武器")]
    public void Load()
    {
        LoadWeaponBottom();
        LoadMainWeapon();
        LoadAccessaryWeapon();
    }

    /// <summary>
    /// 加载武器底座(子类重写该方法可加特效)
    /// </summary>
    public virtual void LoadWeaponBottom()
    {
        //若已存在则延时删除
        GameObject toDestroy = null;
        if (weaponBottom != null) { toDestroy = weaponBottom.gameObject; }

        //加载
        weaponBottom = GameObject.Instantiate(GameSystem.weaponSystem.getPrefab(weaponBottomEnum), transform).GetComponent<WeaponBottom>();
        if (mainWeapon != null) mainWeapon.transform.SetParent(weaponBottom.mainWeaponPosition, false);

        //删除
        if (toDestroy != null) DestroyImmediate(toDestroy);
    }

    /// <summary>
    /// 加载主武器(子类重写该方法可加特效)
    /// </summary>
    public virtual void LoadMainWeapon()
    {
        //错误检测
        if (weaponBottom == null)
        {
            Debug.LogError("必须先有底座才能加载主武器！");
            return;
        }

        //若已存在则延时删除
        GameObject toDestroy = null;
        if (mainWeapon != null) { toDestroy = mainWeapon.gameObject; }

        //加载
        mainWeapon = GameObject.Instantiate(GameSystem.weaponSystem.getPrefab(mainWeaponEnum), weaponBottom.mainWeaponPosition).GetComponent<MainWeapon>();
        if (accessaryWeapon != null)
        {
            accessaryWeapon.SetPosition(mainWeapon.accessaryWeaponPositionL, mainWeapon.accessaryWeaponPositionR);
        }

        //删除
        if (toDestroy != null) DestroyImmediate(toDestroy);
    }

    /// <summary>
    /// 加载副武器(子类重写该方法可加特效)
    /// </summary>
    public virtual void LoadAccessaryWeapon()
    {
        //错误检测
        if (mainWeapon == null)
        {
            Debug.LogError("必须先有主武器才能加载副武器！");
            return;
        }

        //若已存在则延时删除
        GameObject toDestroy = null;
        if (accessaryWeapon != null) { toDestroy = accessaryWeapon.gameObject; }


        //加载
        accessaryWeapon = GameObject.Instantiate(GameSystem.weaponSystem.getPrefab(accessaryWeaponEnum), transform).GetComponent<AccessaryWeapon>();
        accessaryWeapon.SetPosition(mainWeapon.accessaryWeaponPositionL, mainWeapon.accessaryWeaponPositionR);

        //删除
        if (toDestroy != null) DestroyImmediate(toDestroy);
    }


    //控制方法------------------------------------
    /// <summary>
    /// 转动视角
    /// </summary>
    /// <param name="horizontalQuaternion">水平四元数</param>
    /// <param name="verticalQuaternion">垂直四元数</param>
    public void Rotate(Quaternion horizontalQuaternion, Quaternion verticalQuaternion)
    {
        weaponBottom.Rotate(horizontalQuaternion, verticalQuaternion);
        mainWeapon.Rotate(horizontalQuaternion, verticalQuaternion);
        accessaryWeapon.Rotate(horizontalQuaternion, verticalQuaternion);
    }

    /// <summary>
    /// 移动控制
    /// </summary>
    /// <param name="h">水平输入量</param>
    /// <param name="v">垂直输入量</param>
    public void Move(float h, float v)
    {
        weaponBottom.Move(h, v);
    }

}
