using UnityEngine;

public class DeckTile : MonoBehaviour
{
    [SerializeField] DeckTilesManager manager;
    public GameObject tileObject;
    public GameObject _tileObject=null;
    public Transform spawnpoint;
    public void SetObject(GameObject newUnit)
    {
        tileObject=newUnit;
        tileObject.transform.position=spawnpoint.position;
    }
    public GameObject GetObject()
    {
        _tileObject=tileObject;
        tileObject=null;
        return _tileObject;
    }
    public void OnClick()
    {
        if (tileObject != null)
        {
            manager.Choose(this);
        }
    }
}
