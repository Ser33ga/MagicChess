using UnityEngine;

public class ArcherType : MonoBehaviour, IUnitType
{
    [SerializeField] private GameObject nextUnit;
    public IMove Mover{get;set;}=new BaseMover();
    public IAttack Attacker{get;set;}=new ArcherAttacker();
    public IHealth Health{get;set;}=new BaseHealth();
    public IChooseAim ChooserAim{get;set;} = new BaseChooserAim();
    public IDecide Decider{get;set;}=new MoveUnitDecider();
    public GameObject nextType{get;set;}
    public ISkill Skill{get;set;} = null;
    void Awake()
    {
        nextType=nextUnit;
    }
}
