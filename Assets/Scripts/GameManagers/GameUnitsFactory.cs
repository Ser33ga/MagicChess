using UnityEngine;
using VContainer;
public class GameUnitsFactory
{
    [Inject] UnitsFactory factory;

    public GameObject SpawnUnit(GameObject prefab, Vector3 position, Quaternion rotation, bool isBlueTeam)
    {
        GameObject unit=factory.Create(prefab,position,rotation, isBlueTeam);
        return unit;
    }
}
