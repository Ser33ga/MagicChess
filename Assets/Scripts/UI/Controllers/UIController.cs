using UnityEngine;
using VContainer;
using Cysharp.Threading.Tasks;
public class UIController : MonoBehaviour
{
    [Inject] GameManager gameManager;
    [Inject] GameData gameData;
    [Inject] MoneyManager moneyManager;
    [Inject] SceneLoader sceneLoader;
    [Inject] Timers timers;

    [SerializeField] TimerField timerField;
    [SerializeField] CountField countField;
    [SerializeField] MoneyField moneyField;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject looseScreen;
    [SerializeField] private GameObject choosing;
    [SerializeField] private GameObject general;
    [SerializeField] private GameObject spawnChunks;

    void Start()
    {
        gameManager.BattleStarted+=StartBattle;
        gameManager.ChoosingStarted+=StartChoosing;
        gameManager.MatchStarted+=StartMatch;
        gameManager.MatchEndedRed+=EndMatchRed;
        gameManager.MatchEndedBlue+=EndMatchBlue;
        gameManager.BlueWinRound+=BlueWinRound;
        gameManager.RedWinRound+=RedWinRound;
        moneyManager.MoneySpended+=MoneySpended;
        gameManager.TimerChanged+=TimerChanged;
        MoneySpended();
        BlueWinRound();
        RedWinRound();
    }
    public void StartMatch()
    {
        general.SetActive(true);
    }
    public void EndMatchRed()
    {
        looseScreen.SetActive(true);
    }
    public void EndMatchBlue()
    {
        winScreen.SetActive(true);
    }
    public void StartChoosing()
    {
        choosing.SetActive(true);
    }
    public void StartBattle()
    {
        choosing.SetActive(false);
    }
    public void BlueWinRound()
    {
        countField.UpdateBlueCount(gameData.blueWin);
    }
    public void RedWinRound()
    {
        countField.UpdateRedCount(gameData.redWin);
    }
    public void MoneySpended()
    {
        moneyField.UpdateMoney(moneyManager.blueMoney);
    }
    public void TimerChanged()
    {
        timerField.UpdateTimer(timers.outputChoosingTimer);
    }
    public void OpenMenu()
    {
        sceneLoader.LoadScene("Menu", "Game").Forget();;
    }
    public void EndChoosingBlue()
    {
        gameData.blueChooseEnd=true;
    }
    
    void OnDestroy()
    {
        gameManager.BattleStarted-=StartBattle;
        gameManager.ChoosingStarted-=StartChoosing;
        gameManager.MatchStarted-=StartMatch;
        gameManager.MatchEndedRed-=EndMatchRed;
        gameManager.MatchEndedBlue-=EndMatchBlue;
        gameManager.BlueWinRound-=BlueWinRound;
        gameManager.RedWinRound-=RedWinRound;
        gameManager.TimerChanged+=TimerChanged;
        moneyManager.MoneySpended-=MoneySpended;
    }
}
