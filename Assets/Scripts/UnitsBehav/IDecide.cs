using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public interface IDecide
{
    public void Initialize(UnitData _data, IAttack _attacker, IMove _mover, IChooseAim _aimChooser, UnitsPool _unitsPool,Predicate<GameObject> _predicate,IUnit _unit,UnitSounds _dataSounds);
    public void DecideToDo();
}
public class MoveUnitDecider : IDecide
{
    public UnitData data;
    public UnitSounds dataSounds;//убрать все звуки после ребилда
    IUnit unit;
    IAttack attacker;
    IMove mover;
    IChooseAim aimChooser;
    UnitsPool unitsPool;
    Predicate<GameObject> predicate;
    public void Initialize(UnitData _data, IAttack _attacker, IMove _mover, IChooseAim _aimChooser, UnitsPool _unitsPool,Predicate<GameObject> _predicate,IUnit _unit, UnitSounds _dataSounds)
    {
        unit=_unit;
        data=_data;
        unitsPool=_unitsPool;
        attacker=_attacker;
        mover=_mover;
        aimChooser=_aimChooser;
        predicate=_predicate;
        dataSounds=_dataSounds;
    }
    public void DecideToDo()
    {
        if (data.isBlueTeam){
            data.aim=aimChooser.FindAim(data.transform.position, unitsPool.enemyUnits, predicate);
        }else
        {
            data.aim=aimChooser.FindAim(data.transform.position, unitsPool.friendlyUnits, predicate);
        }
        if (data.aim != null)
        {
            if (Vector3.Distance(data.transform.position, data.aim.transform.position) < data.attackRadius)
            {
                data.transform.rotation=Quaternion.Slerp(data.transform.rotation, Quaternion.LookRotation((data.aim.transform.position-data.transform.position).normalized), Time.deltaTime * data.agent.angularSpeed);
                if(data.condition!=UnitCondition.Attack)
                    {
                        mover.Stop();
                        data.aidioSource.PlayOneShot(dataSounds.attack);
                        unit.StartAttacking();
                    }
            } else {
                if (data.condition != UnitCondition.Run){
                data.condition=UnitCondition.Run;
                data.anim.SetInteger("Condition", (int)data.condition);
                }
                mover.ToMove();
                mover.Move(data.aim.transform.position);
            }
        } else
        {
            mover.Stop();
            if (data.condition != UnitCondition.Idle){
                data.condition=UnitCondition.Idle;
                data.anim.SetInteger("Condition", (int)data.condition); 
            }
        }
    }
}