using UnityEngine;
using VContainer;
using VContainer.Unity;

public class UnitsFactory
{
    [Inject] IObjectResolver container;
    [Inject] UnitsPool pool;
    public GameObject Create(GameObject prefab, Vector3 position, Quaternion rotation, bool isBlueTeam)
    {
        GameObject gUnit=container.Instantiate(prefab, position, rotation);
        IUnit unit =gUnit.GetComponent<IUnit>();
        UnitData data=gUnit.GetComponent<UnitData>();
        if (isBlueTeam)
        {
            pool.AddToFriendly(gUnit);
        } else
        {
            pool.AddToEnemy(gUnit);
        }
        unit.Initialize(isBlueTeam);
        return gUnit;
    }
}
