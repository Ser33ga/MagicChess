using System;
using UnityEngine;
using UnityEngine.AI;
[System.Serializable]
public class UnitData : MonoBehaviour
{
    public event Action hpChanged;
    public GameObject aim;
    [SerializeField]private int _health;
    public string enemyPriorityTag;
    public float attackRadius;
    public NavMeshAgent agent;
    public AudioSource aidioSource;
    public Animator anim;
    public float TickTime;
    public int health{get => _health; set
        {
            _health=value;
            hpChanged?.Invoke();
        }
    }
    public int startHealth;
    public int damage;
    public float attackDelay;
    public float projectileSpeed;
    public GameObject Projectile;
    public FloorSegment segment;
    public bool isBlueTeam;
    public UnitCondition condition;
    public float speed;
    public bool canMove;
    public int level;
    public int cost;
    public bool isBought;
    public IUnitType unitType;
    public ProjectileManage projManager;
    public GameObject InstantiateProjectile()
    {
        GameObject proj=Instantiate(Projectile, transform.position, Projectile.transform.rotation);
        return proj;
    }
}
