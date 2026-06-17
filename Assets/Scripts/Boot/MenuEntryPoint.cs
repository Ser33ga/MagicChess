using UnityEngine;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using System.Threading;
using VContainer;
public class MenuEntryPoint : IAsyncStartable
{
    [Inject] IInputReciever reciever;
    [Inject] InputHandler handler;
    public async UniTask StartAsync(CancellationToken token = default)
    {
         handler.reciever=reciever;
    }
}