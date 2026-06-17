using UnityEngine;

public interface IUnit
{
    public IMove Mover{get;set;}
    public IAttack Attacker{get;set;}
    public IHealth Health{get;set;}
    public IChooseAim ChooserAim{get;set;}
    public UnitData data{get;set;}
    public UnitSounds dataSounds{get;set;}
    public IDecide Decider{get;set;}
    public IUnitType unitType{get;set;}
    public void Initialize(bool isBlue);
    public void Die();
    public void RemoveUpdateSubs();
    public void AddUpdateSubs();
    public void StartAttacking();
    public void DisableAgent();
    public void EnableAgent();
}