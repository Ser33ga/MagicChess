using Unity.Android.Gradle.Manifest;
using UnityEngine;
using System.Collections;
using System;
public interface IHealth
{
    public UnitData data{get;set;}
    public UnitSounds dataSounds{get;set;}
    public void GetDamage(int damage);
    public void Initialize(UnitData _data,IUnit _unit,UnitSounds sounds);
    public void Dying(IMove Mover, UnitsPool unitsPool, TickSystem tickSystem, TickSystem.TickTask taskUpdate, GameObject gameObject);
}
public class BaseHealth : IHealth
{
    IUnit unit;
    public UnitData data{get;set;}
    public UnitSounds dataSounds{get;set;}
    public void Initialize(UnitData _data,IUnit _unit, UnitSounds _sounds)
    {
        unit=_unit;
        data=_data;
        data.health=data.startHealth;
        dataSounds=_sounds;
    }
    public void GetDamage(int damage)
    {
        if (data.health - damage > 0)
        {
            data.aidioSource.PlayOneShot(dataSounds.hit);
            data.health -= damage;
        } else
        {
            data.health=0;
            Die();
            data.aidioSource.PlayOneShot(dataSounds.die);
        }
    }
    public void Die()
    {
        unit.Die();
    }
    public void Dying(IMove Mover, UnitsPool unitsPool, TickSystem tickSystem, TickSystem.TickTask taskUpdate, GameObject gameObject)
    {
        data.condition=UnitCondition.Death;
        data.anim.SetInteger("Condition", (int)data.condition);
        Mover.Stop();
        if (data.isBlueTeam)
        {
            unitsPool.RemoveFromFriendly(gameObject);
            unitsPool.AddToDead(gameObject);
        } else
        {
            unitsPool.RemoveFromEnemy(gameObject);
            unitsPool.AddToDead(gameObject);
        }
        tickSystem.DeleteFromTasks(taskUpdate);
        gameObject.GetComponent<UnitData>().segment.GetObject();
        gameObject.SetActive(false);
        //UnityEngine.Object.Destroy(gameObject);
        //yield return null;
    }
}