using UnityEngine;

public interface IUnitType
{
    public IMove Mover{get;set;}
    public IAttack Attacker{get;set;}
    public IHealth Health{get;set;}
    public IChooseAim ChooserAim{get;set;}
    public IDecide Decider{get;set;}
    public GameObject nextType{get;set;}
    public ISkill Skill{get;set;}
}

