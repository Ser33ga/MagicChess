using System.Collections.Generic;
using UnityEngine;
using VContainer;
public class TilesManager:MonoBehaviour
{
    [Inject] MoneyManager moneyManager;
    [Inject] GameManager gameManager;
    [Inject] UnitsPool unitsPool;
    public List<GameObject> EnemyTiles;
    public List<GameObject> FriendlyTiles;
    public GameObject cellPlaceBlue;
    void Start()
    {
        cellPlaceBlue.GetComponent<SellSegment>().Init(moneyManager,unitsPool);
        gameManager.BattleStarted+=cellPlaceBlue.GetComponent<SellSegment>().Sell;
    }
    void OnDestroy()
    {
        gameManager.BattleStarted-=cellPlaceBlue.GetComponent<SellSegment>().Sell;
    }
}
