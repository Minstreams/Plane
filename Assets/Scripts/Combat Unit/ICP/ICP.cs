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
    private GameSystem.WeaponSystem.WeaponBottomEnum weaponBottomEnum;
    [ContextMenuItem("LoadPrimaryWeapon", "LoadPrimaryWeapon")]
    [SerializeField]
    private GameSystem.WeaponSystem.PrimaryWeaponEnum primaryWeaponEnum;
    [ContextMenuItem("LoadSecondaryWeapon", "LoadSecondaryWeapon")]
    [SerializeField]
    private GameSystem.WeaponSystem.SecondaryWeaponEnum secondaryWeaponEnum;




    //结构组成-------------------------------------
    [HideInInspector, SerializeField]
    private WeaponBottom weaponBottom;
    [HideInInspector, SerializeField]
    private PrimaryWeapon primaryWeapon;
    [HideInInspector, SerializeField]
    private SecondaryWeapon secondaryWeapon;
    /// <summary>
    /// 核心位置
    /// </summary>
    public override Transform corePosition { get { return primaryWeapon.corePosition; } }

    [Header("装甲数据"), SerializeField]
    private GameSystem.WeaponSystem.ArmorData armor;
    public override GameSystem.WeaponSystem.ArmorData Armor
    {
        get
        {
            return armor;
        }
    }




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
        LoadPrimaryWeapon();
        LoadSecondaryWeapon();

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
        weaponBottom = GameObject.Instantiate(GameSystem.WeaponSystem.getPrefab(weaponBottomEnum), transform).GetComponent<WeaponBottom>();
        weaponBottom.AttachICP(this);
        if (primaryWeapon != null) primaryWeapon.transform.SetParent(weaponBottom.primaryWeaponPosition, false);

        //删除
        if (toDestroy != null) DestroyImmediate(toDestroy);
    }
    /// <summary>
    /// 加载主武器(子类重写该方法可加特效)
    /// </summary>
    public virtual void LoadPrimaryWeapon()
    {
        //错误检测
        if (weaponBottom == null)
        {
            Debug.LogError("必须先有底座才能加载主武器！");
            return;
        }

        //若已存在则延时删除
        GameObject toDestroy = null;
        if (primaryWeapon != null) { toDestroy = primaryWeapon.gameObject; }

        //加载
        primaryWeapon = GameObject.Instantiate(GameSystem.WeaponSystem.getPrefab(primaryWeaponEnum), weaponBottom.primaryWeaponPosition).GetComponent<PrimaryWeapon>();
        primaryWeapon.AttachICP(this);
        if (secondaryWeapon != null)
        {
            secondaryWeapon.SetPosition(primaryWeapon.secondaryWeaponPositionL, primaryWeapon.secondaryWeaponPositionR);
        }

        //删除
        if (toDestroy != null) DestroyImmediate(toDestroy);
    }
    /// <summary>
    /// 加载副武器(子类重写该方法可加特效)
    /// </summary>
    public virtual void LoadSecondaryWeapon()
    {
        //错误检测
        if (primaryWeapon == null)
        {
            Debug.LogError("必须先有主武器才能加载副武器！");
            return;
        }

        //若已存在则延时删除
        GameObject toDestroy = null;
        if (secondaryWeapon != null) { toDestroy = secondaryWeapon.gameObject; }


        //加载
        secondaryWeapon = GameObject.Instantiate(GameSystem.WeaponSystem.getPrefab(secondaryWeaponEnum), transform).GetComponent<SecondaryWeapon>();
        secondaryWeapon.AttachICP(this);
        secondaryWeapon.SetPosition(primaryWeapon.secondaryWeaponPositionL, primaryWeapon.secondaryWeaponPositionR);

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
    /// <summary>
    /// 主武器发射
    /// </summary>
    public void LaunchPrimaryWeapon()
    {
        primaryWeapon.Launch();
    }
    /// <summary>
    /// 主武器停止发射
    /// </summary>
    public void StopLaunchPrimaryWeapon()
    {
        primaryWeapon.StopLaunching();
    }
    /// <summary>
    /// 副武器发射
    /// </summary>
    public void LaunchSecondaryWeapon()
    {
        secondaryWeapon.Launch();
    }
    /// <summary>
    /// 副武器停止发射
    /// </summary>
    public void StopLaunchSecondaryWeapon()
    {
        secondaryWeapon.StopLaunching();
    }


    //控制下层------------------------------------
    private void Update()
    {
        primaryWeapon.corePosition.rotation = Quaternion.Euler(-vAngle, hAngle, 0);

        weaponBottom.RotateAngle(hAngle, vAngle);
        primaryWeapon.RotateAngle(hAngle, vAngle);
        secondaryWeapon.RotateAngle(hAngle, vAngle);
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
