using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹类
/// </summary>
[RequireComponent(typeof(SphereCollider))]
public abstract class Bullet : MonoBehaviour
{
    /// <summary>
    /// 武器引用
    /// </summary>
    public Weapon weapon { private get; set; }


    private void OnTriggerEnter(Collider other)
    {
        //敌人判定&&伤害计算
        DestroibleObject enemy = other.GetComponent<DestroibleObject>();
        if (enemy == null)
        {
            //撞到障碍物
            Die();
            return;
        }
        if (GameSystem.WarSystem.ableToDamage(weapon.Camp, enemy.Camp))
        {
            //若能造成伤害
            Hit(ref enemy);
            return;
        }
    }

    private void Start()
    {
        Invoke("Die", GameSystem.WeaponSystem.bulletDieSeconds);
    }

    private void Hit(ref DestroibleObject enemy)
    {
        enemy.Damage(GameSystem.WeaponSystem.Damage(enemy.Armor, weapon.BulletData));
        weapon.OnHittingEnemy();
        print(enemy + "hited!");
        Die();
    }
    private void Die()
    {
        CancelInvoke();
        Destroy(gameObject);
    }

    protected abstract void Update();
    //测试方法
#if UNITY_EDITOR
    private void Reset()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }
#endif
}
