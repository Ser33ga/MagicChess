using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ArcherVonfig", menuName = "Scriptable Objects/ArcherVonfig")]
public class UnitConfig : ScriptableObject, IUnitConfig
{
    [SerializeField] private string _enemyPriorityTag;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _TickTime;
    [SerializeField] private int _startHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private GameObject _Projectile;
    [SerializeField] private bool _isBlueTeam;
    [SerializeField] private float _speed;
    [SerializeField] private int _level;
    [SerializeField] private int _cost;
    [SerializeField] private bool _isBought;



    public string enemyPriorityTag =>_enemyPriorityTag;
    public float attackRadius => _attackRadius;
    public float TickTime => _TickTime;
    public int startHealth => _startHealth;
    public int damage => _damage;
    public float attackDelay => _attackDelay;
    public float projectileSpeed =>_projectileSpeed;
    public GameObject Projectile =>_Projectile;
    public bool isBlueTeam =>_isBlueTeam;
    public float speed =>_speed;
    public int level =>_level;
    public int cost =>_cost;
    public bool isBought =>_isBought;

    [SerializeField] private AudioClip _going;
    [SerializeField] private AudioClip _attack;
    [SerializeField] private AudioClip _hit;
    [SerializeField] private AudioClip _die;

    public AudioClip going=>_going;
    public AudioClip attack=>_attack;
    public AudioClip hit=>_hit;
    public AudioClip die=>_die;

    
    public void InitializeData(UnitData data)
    {
        data.enemyPriorityTag=enemyPriorityTag;
        data.attackRadius=attackRadius;
        data.TickTime=TickTime;
        data.startHealth=startHealth;
        data.damage=damage;
        data.attackDelay=attackDelay;
        data.projectileSpeed=projectileSpeed;
        if (Projectile != null)
        {
            data.Projectile=Projectile;
        }
        data.isBlueTeam=isBlueTeam;
        data.speed=speed;
        data.level=level;
        data.cost=cost;
        data.isBought=isBought;
    }

    public void InitializeSoundData(UnitSounds data)
    {
        data.attack=attack;
        data.die=die;
        data.hit=hit;
        data.going=going;
    }
    
}
