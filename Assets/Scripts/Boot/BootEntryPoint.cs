using UnityEngine;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using System.Threading;
using VContainer;
using Firebase;
using Firebase.Analytics;
using System.Threading.Tasks;
public class BootEntryPoint : IAsyncStartable
{
    
    [Inject] readonly SceneLoader sceneLoader;
    public async UniTask StartAsync(CancellationToken token = default)
    {
        var task = FirebaseApp.CheckAndFixDependenciesAsync();
        await task;
        if (task.Result == DependencyStatus.Available)
        {
            Debug.Log("Firebase is on");
            FirebaseAnalytics.LogEvent("level_start");
            
        }
        await sceneLoader.LoadScene("Menu","Boot", token);
    }
}
