using UnityEngine;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using System.Threading;
using VContainer;
public class GameEntryPoint : IAsyncStartable
{
    [Inject] GameManager gameManager;
    [Inject] ProxyBetweenScenes proxyBetweenScenes;
    [Inject] DeckManager deckManager;
    [Inject] IInputReciever reciever;
    [Inject] InputHandler handler;

    public async UniTask StartAsync(CancellationToken token = default)
    {
        handler.reciever=reciever;

        deckManager.friendlyDeck=proxyBetweenScenes.deckPreferences.deckBlue;
        deckManager.enemyDeck=proxyBetweenScenes.deckPreferences.deckRed;
        
        gameManager.OnStart();
    }
}