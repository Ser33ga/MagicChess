using UnityEngine;

public class UiControllerMenu : MonoBehaviour
{
    [SerializeField] GameObject startGameScreen;
    [SerializeField] GameObject deckChoosingScreen;
    
    public void EnterstartGameScreen()
    {
        deckChoosingScreen.SetActive(false);
        startGameScreen.SetActive(true);
    }
    public void EnterdeckChoosingScreen()
    {
        startGameScreen.SetActive(false);
        deckChoosingScreen.SetActive(true); 
    }
}
