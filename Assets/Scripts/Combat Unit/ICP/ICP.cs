using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 集成作战平台 Integrated Combat Platform
/// </summary>
[DisallowMultipleComponent]
[AddComponentMenu("Combat Unit/ICP")]
public class ICP : CombatUnit
{
    //型号记录-------------------------------------
    [ContextMenuItem("LoadWeaponBottom", "LoadWeaponBottom")]
    [SerializeField]
    private WeaponSystem.WeaponBottomEnum weaponBottomEnum;
    [ContextMenuItem("LoadMainWeapon", "LoadMainWeapon")]
    [SerializeField]
    private WeaponSystem.MainWeaponEnum mainWeaponEnum;
    [ContextMenuItem("LoadAccessaryWeapon", "LoadAccessaryWeapon")]
    [SerializeField]
    private WeaponSystem.AccessaryWeaponEnum accessaryWeaponEnum;




    //结构组成-------------------------------------
    [HideInInspector, SerializeField]
    private WeaponBottom weaponBottom;
    [HideInInspector, SerializeField]
    private MainWeapon mainWeapon;
    [HideInInspector, SerializeField]
    private AccessaryWeapon accessaryWeapon;
    /// <summary>
    /// 核心位置
    /// </summary>
    public Transform corePosition { get { return mainWeapon.corePosition; } }




    //加载武器-------------------------------------
    /// <summary>
    /// 根据Enum的值加载武器
    /// </summary>
    [ContextMenu("加载武器")]
    public void Load()
    {
        if (BeforeLoad != null)
        {
            BeforeLoad();
        }
        //清空子物体
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        //加载
        LoadWeaponBottom();
        LoadMainWeapon();
        LoadAccessaryWeapon();

        if (AfterLoad != null)
        {
            AfterLoad();
        }
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

    public event Action BeforeLoad;
    public event Action AfterLoad;

    //参数----------------------------------------
    [SerializeField]
    [Range(10, 90)]
    [Header("上仰角限制")]
    private float upAngleLimit = 90;
    [SerializeField]
    [Range(10, 90)]
    [Header("下俯角限制")]
    private float downAngleLimit = 30;

    /// <summary>
    /// 水平旋转角
    /// </summary>
    private float hAngle = 0;
    /// <summary>
    /// 垂直旋转角
    /// </summary>
    private float vAngle = 0;





    //控制方法------------------------------------
    /// <summary>
    /// 转动视角
    /// </summary>
    /// <param name="hAngle">水平分量变化量</param>
    /// <param name="vAngle">垂直分量变化量</param>
    public void RotateAngle(float hDeltaAngle, float vDeltaAngle)
    {
        hAngle += hDeltaAngle;
        vAngle = Mathf.Clamp(vAngle + vDeltaAngle, -downAngleLimit, upAngleLimit);
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



    //控制下层------------------------------------
    private void Update()
    {
        mainWeapon.corePosition.rotation = Quaternion.Euler(-vAngle, hAngle, 0);

        weaponBottom.RotateAngle(hAngle, vAngle);
        mainWeapon.RotateAngle(hAngle, vAngle);
        accessaryWeapon.RotateAngle(hAngle, vAngle);
    }
}
