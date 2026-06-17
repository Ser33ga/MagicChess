using UnityEngine;

public class SellSegment : MonoBehaviour
{
    private MoneyManager moneyManager;
    private FloorSegment segment;
    private UnitsPool pool;
    public void Init(MoneyManager mManager,UnitsPool uPool)
    {
        pool=uPool;
        moneyManager=mManager;
    }
    void Start()
    {
        segment=GetComponent<FloorSegment>();
    }
    public void Sell()
    {
        if (segment.unit!=null)
        {
            GameObject _unit=segment.GetObject();
            moneyManager.GetMoney(_unit.GetComponent<UnitData>().cost,true);
            _unit.GetComponent<IUnit>().RemoveUpdateSubs();
            pool.RemoveFromFriendly(_unit);
            Destroy(_unit);
        }
    }
}
