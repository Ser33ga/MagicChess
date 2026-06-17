using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Cysharp.Threading.Tasks;
using System.Threading;
public class BoardManager
{
    public GameObject currentUnit;
    public FloorSegment currentSegment;
    [Inject] GameUnitsFactory factory;
    private GameManager manager;
    [Inject] MoneyManager moneyManager;
    [Inject] TilesManager tilesManager;
    [Inject]
    public BoardManager(GameManager manager)
    {
    this.manager = manager;
    manager.BattleStarted += CancelPutting;
    }
    public bool PlaceUnit(FloorSegment segment, GameObject unit)
    {
        if (!segment.isStartCell)
        {
            if (segment.unit == null)
            {
                if (segment.isBlue == unit.GetComponent<UnitData>().isBlueTeam)
                {
                segment.SetObject(unit);
                return true;
                }
                return false;
            }
            else
            {
                if (segment.unit.GetComponent<IUnitType>().GetType() == unit.GetComponent<IUnitType>().GetType() && unit.GetComponent<IUnitType>().GetType()!=null)
                {
                    if (segment.unit.GetComponent<UnitData>().isBlueTeam == unit.GetComponent<UnitData>().isBlueTeam)
                    {
                        if (unit.GetComponent<IUnitType>().nextType != null)
                        {
                           MergeUnits(segment.unit, segment);
                            return true; 
                        }
                        return false;
                    }
                    return false;
                } else
                {
                    return false;
                }
            }
        } else
        {
            return false;
        }
    }
    public bool TakeUnit(FloorSegment segment, GameObject unit){
        if (!segment.isStartCell)
        {
            currentSegment=segment;
            currentUnit=unit; 
            segment.GetObject();
            return true;
        } else
        {
            if (moneyManager.SpendMoney(unit.GetComponent<UnitData>().cost, unit.GetComponent<UnitData>().isBlueTeam))
            {
                unit.GetComponent<UnitData>().isBought=true;
                currentSegment=segment;
                currentUnit=unit; 
                segment.GetObject(); 
                return true;
            }else
            {
                return false;
            }
        }
    }
    public bool PutUnit(FloorSegment segment, GameObject unit)
    {
        if (PlaceUnit(segment, unit)==false)
        {
            currentSegment.SetObject(currentUnit);
            return false;
        } else
        {
            currentSegment=null;
            currentUnit=null; 
            return true;
        }
    }
    public void CancelPutting()
    {
        if (currentUnit!=null)
        {
            if (currentSegment.isStartCell)
            {
                moneyManager.GetMoney(
                currentUnit.GetComponent<UnitData>().cost,
                currentUnit.GetComponent<UnitData>().isBlueTeam
                );
                currentUnit.GetComponent<UnitData>().isBought = false;
                currentSegment.SetObject(currentUnit);
                currentSegment=null;
                currentUnit=null; 
            } else
            {
                currentSegment.SetObject(currentUnit);
                currentSegment=null;
                currentUnit=null; 
            } 
        }
    }
    public void MergeUnits(GameObject unit, FloorSegment segment)
    {
        if (!segment.isStartCell)
        {
            segment.GetObject();
            GameObject newUnit=factory.SpawnUnit(unit.GetComponent<IUnitType>().nextType,segment.transform.position,segment.transform.rotation, true);
            unit.GetComponent<IUnit>().RemoveUpdateSubs();
            manager.DestroySmt(unit);
            segment.SetObject(newUnit);
            currentUnit.GetComponent<IUnit>().RemoveUpdateSubs();
            manager.DestroySmt(currentUnit);
            currentUnit=null;
        }
    }
    /*public bool Cell()
    {
        FloorSegment segment=tilesManager.cellPlaceBlue.GetComponent<FloorSegment>();
        if (segment.unit != null)
        {
            GameObject unit=segment.GetObject();
            moneyManager.GetMoney(unit.GetComponent<UnitData>().cost, true);
            unit.GetComponent<IUnit>().RemoveUpdateSubs();
            manager.DestroySmt(unit);
            currentUnit=null;
            return true;
        }
        else
        {
            return false;
        }
    }*/
}
