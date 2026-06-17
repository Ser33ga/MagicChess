using UnityEngine;
using VContainer;
using System.Collections;
using System;
public class GameManager : MonoBehaviour
{
    [Inject] UnitStartSpawner startSpawner;
    [Inject] UnitsPool pool;
    [Inject] Timers timers;
    [Inject] GameData data;
    [Inject] MoneyManager mManager;
    [Inject] GameSceneSound gameSceneSound;
    public GameCondition condition;
    public event Action ChoosingStarted;
    public event Action BattleStarted;
    public event Action MatchStarted;
    public event Action MatchEndedRed;
    public event Action MatchEndedBlue;
    public event Action BlueWinRound;
    public event Action RedWinRound;
    public event Action TimerChanged;
    [SerializeField] private ScriptableObject configAsset;
    public GameDataConfig config => (GameDataConfig)configAsset;
    public IEnumerator StartMatch()
    {
        condition=GameCondition.Choosing;
        yield return null;
        data.gameIsActive=true;
        StartChoosing();
        MatchStarted?.Invoke();
    }
    public void StartChoosing()
    {
        data.blueChooseEnd=false;
        data.redChooseEnd=false;
        StartCoroutine(timers.ChoosingCount());
        mManager.GetMoney(data.MoneyAddEachRound[data.roundNumber],true);
        mManager.GetMoney(data.MoneyAddEachRound[data.roundNumber],false);
        condition=GameCondition.Choosing;
        Debug.Log("StartChoosing");
        
        ChoosingStarted?.Invoke();
        RestoreUnits();
        startSpawner.InitializeCells();
        
        foreach (GameObject unit in pool.enemyUnits)
        {
            unit.GetComponent<IUnit>().DisableAgent();
        } 
        foreach (GameObject unit in pool.friendlyUnits)
        {
            unit.GetComponent<IUnit>().DisableAgent();
        }
    }
    public void OnStart()
    {
        config.ApplyData(data);
        StartCoroutine(StartMatch());
    }
    public void StartBattle()
    {
        condition=GameCondition.Battle;
        Debug.Log("StartBattle");
        
        BattleStarted?.Invoke();
        startSpawner.ClearCells();
        
        foreach (GameObject unit in pool.enemyUnits)
        {
            unit.GetComponent<IUnit>().EnableAgent();
        }
        foreach (GameObject unit in pool.friendlyUnits)
        {
            unit.GetComponent<IUnit>().EnableAgent();
        }
    }

    public void DestroySmt(GameObject obj)
    {
        Destroy(obj);
    }
    public void EnableAllUnits(UnitsPool pool)
    {
        foreach (GameObject unit in pool.enemyUnits)
        {
            unit.GetComponent<IUnit>().EnableAgent();
        }
        foreach (GameObject unit in pool.friendlyUnits)
        {
            unit.GetComponent<IUnit>().EnableAgent();
        }
    }
    public void DisableAllUnits(UnitsPool pool)
    {
        foreach (GameObject unit in pool.enemyUnits)
        {
            unit.GetComponent<IUnit>().DisableAgent();
        }
        foreach (GameObject unit in pool.friendlyUnits)
        {
            unit.GetComponent<IUnit>().DisableAgent();
        }
    }
    public void RestoreUnits()
    {
        foreach (GameObject unit in pool.friendlyUnits)
        {
            pool.deadUnits.Add(unit);
            unit.SetActive(false);
        }
        foreach (GameObject unit in pool.enemyUnits)
        {
            pool.deadUnits.Add(unit);
            unit.SetActive(false);
        }
        pool.enemyUnits.Clear();
        pool.friendlyUnits.Clear();
        foreach(GameObject unit in pool.deadUnits)
        {
            unit.SetActive(true);
            UnitData data=unit.GetComponent<UnitData>();
            data.segment.SetObject(unit);
            bool isBlueTeam=unit.GetComponent<UnitData>().isBlueTeam;
            data.health=data.startHealth;
            data.condition=UnitCondition.Idle;
            data.anim.SetInteger("Condition", (int)data.condition);
            data.aim=null;
            if (isBlueTeam)
            {
                pool.AddToFriendly(unit);
            } else
            {
                pool.AddToEnemy(unit);
            }
            IUnit _unit=unit.GetComponent<IUnit>();
            _unit.AddUpdateSubs();
        }
        pool.deadUnits.Clear();
    }
    public bool EndBattle()
    {
        if (pool.enemyUnits.Count == 0)
        {
            BlueWin();
            if (data.blueWin == data.roundsToWin)
            {
                EndMatch(true);
                return true;
            }
            return true;
        }
        if (pool.friendlyUnits.Count == 0)
        {
            RedWin();
            if (data.redWin == data.roundsToWin)
            {
                EndMatch(false);
                return true;
            }
            return true;
        }
        return false;
    }
    void Update()
    {
        if(data.gameIsActive)
        {
            if (condition == GameCondition.Battle)
            {
                if(EndBattle())
                {
                    StartChoosing();
                }
            }
            if (condition == GameCondition.Choosing)
            {
                if(timers.isBattleReady || (data.redChooseEnd && data.blueChooseEnd))
                {
                    StartBattle();
                }
                TimerChanged?.Invoke();
            }
        }
    }
    public void RedWin()
    {
        data.roundNumber+=1;
        data.redWin+=1;
        gameSceneSound.PlayWinRoundSound();
        RedWinRound?.Invoke();
        Debug.Log("RedWinRound");
    }
    public void BlueWin()
    {
        data.roundNumber+=1;
        data.blueWin+=1;
        gameSceneSound.PlayLooseRoundSound();
        BlueWinRound?.Invoke();
        Debug.Log("BlueWinRound");
    }
    public void EndMatch(bool isBlueWin)
    {
        if (isBlueWin)
        {
            Debug.Log("BlueWinMatch");
            gameSceneSound.PlayWinGameSound();
            MatchEndedBlue?.Invoke();
        } else
        {
            Debug.Log("RedWinMatch");
            gameSceneSound.PlayLooseGameSound();
            MatchEndedRed?.Invoke();    
        }
        data.gameIsActive=false;
    }
}
