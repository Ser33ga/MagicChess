using System;
using UnityEngine;
using VContainer;

public class MenuEventBus : MonoBehaviour
{
    [Inject] private MenuSceneSound menuSceneSound;
    public event Action GameFromMenu;
    public void _GameFromMenu()
    {
        menuSceneSound.PlayClickSound();
        GameFromMenu?.Invoke();
    }
}
