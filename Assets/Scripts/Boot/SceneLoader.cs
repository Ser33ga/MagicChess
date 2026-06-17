using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System.Threading;
using VContainer.Unity;
using VContainer;
using System;
using System.Threading.Tasks;
public class SceneLoader
{
    [Inject]public LifetimeScope lifeTimeScope;
    private bool isLoading=false;
    public async UniTask LoadScene(string loadscenename,string unloadscenename, CancellationToken token = default)
    {
        if (isLoading==false)
        {
            isLoading=true;
            await UniTask.Yield(token);

            using (LifetimeScope.EnqueueParent(lifeTimeScope))
            {
                var loadOperation=SceneManager.LoadSceneAsync(loadscenename, LoadSceneMode.Additive);

                loadOperation.allowSceneActivation=false;
                while (loadOperation.progress < 0.9f )
                {
                    await UniTask.Yield(token);
                }
                loadOperation.allowSceneActivation = true;
                await loadOperation.ToUniTask(cancellationToken: token);
            }

            var unloadOperation=SceneManager.UnloadSceneAsync(unloadscenename);
            while (unloadOperation.isDone == false)
            {
                await UniTask.Yield(token);
            }
            await unloadOperation.ToUniTask(cancellationToken: token);
            isLoading=false;
        }
    }
}