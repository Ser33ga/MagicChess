using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "GameDataConfig", menuName = "Scriptable Objects/GameDataConfig")]
public class GameDataConfig : ScriptableObject
{
    public float ChoosingTime;
    public bool blueChooseEnd;
    public bool redChooseEnd;
    public bool gameIsActive=false;
    public int redWin;
    public int blueWin;
    public int roundsToWin;
    public int roundNumber;
    public List<int> MoneyAddEachRound=new List<int> {};
    public void ApplyData(GameData data)
    {
        data.ChoosingTime=ChoosingTime;
        data.blueChooseEnd=blueChooseEnd;
        data.redChooseEnd=redChooseEnd;
        data.gameIsActive=gameIsActive;
        data.redWin=redWin;
        data.blueWin=blueWin;
        data.roundsToWin=roundsToWin;
        data.roundNumber=roundNumber;
    }
}
