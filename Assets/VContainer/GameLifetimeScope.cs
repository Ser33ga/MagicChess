using UnityEngine;
using VContainer.Unity;
using VContainer;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<GameEntryPoint>(Lifetime.Scoped);
        builder.Register<UnitsFactory>(Lifetime.Scoped);
        builder.RegisterComponentOnNewGameObject<TickSystem>(Lifetime.Singleton, "TickSystem");
        builder.Register<GameUnitsFactory>(Lifetime.Scoped);
        builder.Register<BoardManager>(Lifetime.Scoped);
        builder.Register<MoneyManager>(Lifetime.Scoped);
        builder.RegisterComponent(FindObjectOfType<InputPlayer>());
        builder.Register<UnitsPool>(Lifetime.Scoped);
        builder.RegisterComponent(FindObjectOfType<UnitStartSpawner>());
        builder.RegisterComponent(FindObjectOfType<GameManager>());
        builder.RegisterComponent(FindObjectOfType<GameData>());
        builder.RegisterComponent(FindObjectOfType<Timers>());
        builder.RegisterComponent(FindObjectOfType<TilesManager>());
        builder.RegisterComponent(FindObjectOfType<AIPlayer>());
        builder.RegisterComponent(FindObjectOfType<DeckManager>());
        builder.RegisterComponent(FindObjectOfType<UIController>());
        builder.RegisterComponent(FindObjectOfType<GameSceneSound>());
        builder.RegisterComponentInHierarchy<InputPlayer>().As<IInputReciever>();
    }
}
