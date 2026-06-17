using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
public class MenuController : MonoBehaviour
{
    [Inject] ProxyBetweenScenes proxyBetweenScenes;
    [Inject] DeckTilesManager deckTilesManager;
    [Inject] EnemyDeckBuilder enemyDeckBuilder;
    [Inject] SceneLoader sceneLoader;
    [Inject] MenuEventBus eventBus;
    void Start()
    {
        eventBus.GameFromMenu+=LoadGameFromMenu;
    }
    public void LoadGameFromMenu()
    {
        if (deckTilesManager.SaveDeck())
        {
            enemyDeckBuilder.BuildDeck();
            proxyBetweenScenes.deckPreferences.deckRed=enemyDeckBuilder.chosenEnemyDeck;
            proxyBetweenScenes.deckPreferences.deckBlue=deckTilesManager.units;
            sceneLoader.LoadScene("Game", "Menu").Forget();
        }
    }
    void OnDestroy()
    {
        eventBus.GameFromMenu-=LoadGameFromMenu;
    }
}
