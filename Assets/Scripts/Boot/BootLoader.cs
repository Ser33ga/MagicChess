using UnityEngine;
using VContainer.Unity;
using VContainer;
using Cysharp.Threading.Tasks;
public class BootLoader: MonoBehaviour
{
    [Inject] readonly SceneLoader sceneLoader;
    void Start()
    {
        //sceneLoader.LoadScene("Menu","Boot").Forget();
    }
}