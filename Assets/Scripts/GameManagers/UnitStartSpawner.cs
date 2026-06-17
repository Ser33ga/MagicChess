using System.Collections.Generic;
using UnityEngine;
using VContainer;
public class UnitStartSpawner : MonoBehaviour
{
    [Inject] GameUnitsFactory factory;
    [Inject] UnitsPool pool;
    [Inject] DeckManager deckManager;
    public List<GameObject> units => deckManager.friendlyDeck;
    public List<FloorSegment> places=new List<FloorSegment>{};

    public void InitializeCells()
    {
        foreach (FloorSegment segment in places)
        { 
            GameObject choosedUnit = units[Random.Range(0, units.Count)];
            GameObject unit = factory.SpawnUnit(choosedUnit, segment.gameObject.transform.position, segment.gameObject.transform.rotation,true);
            segment.SetObject(unit);
        }
    } 
    public void ClearCells()
    {
        foreach (FloorSegment segment in places)
        {
            if (segment.unit != null)
            {
                segment.unit.GetComponent<IUnit>().RemoveUpdateSubs();
                GameObject unit=segment.GetObject();
                pool.RemoveFromFriendly(unit);
                Destroy(unit);  
            }
        }
    }
}
