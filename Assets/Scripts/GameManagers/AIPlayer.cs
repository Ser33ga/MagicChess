using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Tilemaps;
using VContainer;
public class AIPlayer : MonoBehaviour
{
    [Inject] GameManager gameManager;
    [Inject] GameData gameData;
    [Inject] BoardManager boardManager;
    [Inject] TilesManager tilesManager;
    [Inject] DeckManager deckManager;
    [Inject] MoneyManager moneyManager;
    [Inject] GameUnitsFactory factory;
    public GameObject currentUnit;
    private List<GameObject> freeTiles = new List<GameObject>{};
    void Start()
    {
        gameManager.ChoosingStarted+=PrepareUnits;
        gameManager.BattleStarted+=OnBattle;
    }

    public void PrepareUnits()
    {
        while (true)
        {
            GameObject title=ChooseRandomTile();
            GameObject unit=ChooseUnit();
            if (unit == null || title==null)
            {
                gameData.redChooseEnd=true;
                break;
            } else
            {
                moneyManager.SpendMoney(unit.GetComponent<UnitData>().cost, false);
                GameObject newUnit=factory.SpawnUnit(unit, title.transform.position, title.transform.rotation, false);
                boardManager.PlaceUnit(title.GetComponent<FloorSegment>(),newUnit);
                gameData.redChooseEnd=true;
            }
        }
    }
    public void OnBattle()
    {
        gameData.redChooseEnd=false;
    }
    public GameObject ChooseRandomTile()
    {
        GameObject choosedTile=null;
        foreach(GameObject tile in tilesManager.EnemyTiles)
        {
            if (tile.GetComponent<FloorSegment>().unit == null)
            {
                freeTiles.Add(tile);
            }
        }
        if (freeTiles.Count != 0)
        {
            choosedTile = freeTiles[Random.Range(0, freeTiles.Count)];
            freeTiles.Clear();
            return choosedTile;
        } else
        {
            freeTiles.Clear();
            return choosedTile;
        }
    }
    public GameObject ChooseUnit()
    {
        int maxcost=0;
        GameObject unit=null;
        foreach (GameObject _unit in deckManager.enemyDeck)
        {
            if (_unit.GetComponent<UnitData>().cost > maxcost && _unit.GetComponent<UnitData>().cost<=moneyManager.redMoney)
            {
                maxcost=_unit.GetComponent<UnitData>().cost;
                unit=_unit;
            }
        }
        return unit;
    }
    void OnDestroy()
    {
        gameManager.ChoosingStarted-=PrepareUnits;
        gameManager.BattleStarted-=OnBattle;
    }
}
