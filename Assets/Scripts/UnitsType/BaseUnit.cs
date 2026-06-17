using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using VContainer;
 
public class BaseUnit : MonoBehaviour,IUnit
{
    [Inject] TickSystem tickSystem;
    [Inject] UnitsPool unitsPool;
    public IMove Mover{get;set;}
    public IAttack Attacker{get;set;}
    public IHealth Health{get;set;}
    public IChooseAim ChooserAim{get;set;}
    public IDecide Decider{get;set;}
    public UnitData data{get;set;}
    public UnitSounds dataSounds{get;set;}
    public IUnitType unitType{get;set;}
    public TickSystem.TickTask taskUpdate;
    private Predicate<GameObject> predicate;
    private UnitConfigProxy unitConfigProxy;
    private AudioSource source;

    public void Initialize(bool isBlue)
    {
        unitType=gameObject.GetComponent<IUnitType>();
        data=gameObject.GetComponent<UnitData>();
        dataSounds=gameObject.GetComponent<UnitSounds>();
        unitConfigProxy=GetComponent<UnitConfigProxy>();
        source=GetComponent<AudioSource>();

        unitConfigProxy.config.InitializeData(data);
        
        unitConfigProxy.config.InitializeSoundData(dataSounds);
        data.aidioSource=source;
        data.isBlueTeam=isBlue;
        data.condition=UnitCondition.Idle;
        data.anim=GetComponent<Animator>();
        
        data.anim.SetInteger("Condition", (int)data.condition);

        predicate=go => go.CompareTag(data.enemyPriorityTag);
        Mover=new BaseMover();
        Attacker=unitType.Attacker;
        Health=unitType.Health;
        ChooserAim = unitType.ChooserAim;
        Decider=unitType.Decider;

        if (data.projManager != null)
        {
            data.projManager.CreatePool();
        }
        data.agent=gameObject.GetComponent<NavMeshAgent>();
        Mover.Initialize(data.agent, data.speed);
        Attacker.Initialize(data);
        Health.Initialize(data,this,dataSounds);
        Decider.Initialize(data, Attacker,Mover,ChooserAim,unitsPool,predicate,this, dataSounds);
        taskUpdate=tickSystem.AddToTasks(TickUpdate, data.TickTime);
    }
    public void TickUpdate()
    {
        if (data.canMove)
        {
            Decider.DecideToDo();
        }
    }

    public void Die()
    {
        DisableAgent();
        Health.Dying(Mover,unitsPool,tickSystem,taskUpdate,gameObject);
    }
    public void RemoveUpdateSubs()
    {
        tickSystem.DeleteFromTasks(taskUpdate);
    }
    public void AddUpdateSubs()
    {
        taskUpdate=tickSystem.AddToTasks(TickUpdate, data.TickTime);
    }
    public void StartAttacking()
    {
        StartCoroutine(Attacker.Attacking());
    }
    public void DisableAgent()
    {
        data.canMove=false;
        data.agent.enabled=false;
    }
    public void EnableAgent()
    {
        data.canMove=true;
        data.agent.enabled=true;
    }
}