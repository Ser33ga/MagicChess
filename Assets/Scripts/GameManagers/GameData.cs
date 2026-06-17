using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[System.Serializable]
public class GameData : MonoBehaviour
{
    public float ChoosingTime;
    public bool blueChooseEnd;
    public bool redChooseEnd;
    public bool gameIsActive=false;
    public int redWin;
    public int blueWin;
    public int roundsToWin;
    public int roundNumber;
    public List<int> MoneyAddEachRound=new List<int>{};
}
