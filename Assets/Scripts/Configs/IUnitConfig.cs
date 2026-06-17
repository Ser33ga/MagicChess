using UnityEngine;

public interface IUnitConfig
{
    public void InitializeData(UnitData data);
    public void InitializeSoundData(UnitSounds data);
    public string enemyPriorityTag{get;}
    public float attackRadius{get;}
    public float TickTime{get;}
    public int startHealth{get;}
    public int damage{get;}
    public float attackDelay{get;}
    public float projectileSpeed{get;}
    public GameObject Projectile{get;}
    public bool isBlueTeam{get;}
    public float speed{get;}
    public int level{get;}
    public int cost{get;}
    public bool isBought{get;}
    public AudioClip going{get;}
    public AudioClip attack{get;}
    public AudioClip hit{get;}
    public AudioClip die{get;}
}
