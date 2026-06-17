using System.Collections;
using System;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
public interface IAttack
{
    public IEnumerator Attacking();
    public void Initialize(UnitData _data);
}
public class RangerAttacker : IAttack
{
    UnitData data;
    public void Initialize(UnitData _data)
    {
        data=_data;
    }
    public void Attack(IUnit unit, int damage)
    {
        if (unit != null)
        {
            unit.Health.GetDamage(damage);
        }
    }
    public IEnumerator Attacking()
    {
        data.condition=UnitCondition.Attack;
        data.anim.SetInteger("Condition", (int)data.condition);
        yield return new WaitForSeconds(data.attackDelay);
        if (data.aim != null)
        {
            Attack(data.aim.GetComponent<IUnit>(),data.damage);
        }
        data.condition=UnitCondition.Idle;
        data.anim.SetInteger("Condition", (int)data.condition);
    }
}
public class ArcherAttacker : IAttack
{
    UnitData data;
    public void Initialize(UnitData _data)
    {
        data=_data;
    }
    public void Attack(IUnit unit, int damage)
    {
        if (unit != null)
        {
            unit.Health.GetDamage(damage);
        }
    }
    public IEnumerator Attacking()
    {
        data.condition=UnitCondition.Attack;
        data.anim.SetInteger("Condition", (int)data.condition);
        GameObject proj=data.projManager.CreateProjectile();
        proj.GetComponent<Projectile>().aim=data.aim;
        proj.GetComponent<Projectile>().speed=data.projectileSpeed;
        yield return new WaitForSeconds(data.attackDelay);
        if (data.aim != null)
        {
            if (data.aim.activeInHierarchy)
            {
                Attack(data.aim.GetComponent<IUnit>(),data.damage);
            }
        }
        data.condition=UnitCondition.Idle;
        data.anim.SetInteger("Condition", (int)data.condition);
    }
}