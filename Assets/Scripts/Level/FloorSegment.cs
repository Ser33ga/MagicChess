using System;
using UnityEngine;
using UnityEngine.AI;

public class FloorSegment : MonoBehaviour
{
    public GameObject unit=null;
    public Transform spawnpoint;
    public GameObject _unit;
    public bool isBlue;
    public bool isStartCell;
    public bool isBin;
    public event Action SetUnit;
    public event Action GetUnit;
    public void SetObject(GameObject newUnit)
    {
        unit=newUnit;
        unit.transform.position=spawnpoint.position;
        unit.GetComponent<UnitData>().segment=this;
        SetUnit?.Invoke();
    }
    public GameObject GetObject()
    {
        _unit=unit;
        unit=null;
        GetUnit?.Invoke();
        return _unit;
    }
}
