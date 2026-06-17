using UnityEngine;
using VContainer.Unity;
using VContainer;

public class MainLifetimeScoupe : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<BootEntryPoint>(Lifetime.Scoped);
        builder.Register<SceneLoader>(Lifetime.Singleton);
        builder.Register<ProxyBetweenScenes>(Lifetime.Singleton);
        builder.RegisterComponent(FindObjectOfType<Camera>());
        builder.RegisterComponent(FindObjectOfType<BootLoader>());
        builder.RegisterComponentInHierarchy<BootInputReceiver>().As<IInputReciever>();
        builder.RegisterComponent(FindObjectOfType<InputHandler>());
        builder.RegisterComponent(FindObjectOfType<AudioListener>());
        builder.Register<AudioPlayer>(Lifetime.Singleton);
    }
}
