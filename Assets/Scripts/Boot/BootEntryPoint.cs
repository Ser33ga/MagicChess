using UnityEngine;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using System.Threading;
using VContainer;
public class BootEntryPoint : IAsyncStartable
{
    [Inject] readonly SceneLoader sceneLoader;
    public async UniTask StartAsync(CancellationToken token = default)
    {
        await sceneLoader.LoadScene("Menu","Boot", token);
    }
}
