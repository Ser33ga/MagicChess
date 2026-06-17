using UnityEngine;
using VContainer.Unity;
using VContainer;

public class MenuLifetimeScoupe : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<MenuEntryPoint>(Lifetime.Scoped);
        builder.RegisterComponent(FindObjectOfType<MenuController>());
        builder.RegisterComponent(FindObjectOfType<MenuEventBus>());
        builder.RegisterComponent(FindObjectOfType<UiControllerMenu>());
        builder.RegisterComponent(FindObjectOfType<DeckTilesManager>());
        builder.RegisterComponent(FindObjectOfType<EnemyDeckBuilder>());
        builder.RegisterComponent(FindObjectOfType<MenuSceneSound>());
        builder.RegisterComponentInHierarchy<MenuInputReceiver>().As<IInputReciever>();
    }
}