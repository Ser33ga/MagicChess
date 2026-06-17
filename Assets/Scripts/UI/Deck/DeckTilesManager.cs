using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using VContainer;
public class DeckTilesManager : MonoBehaviour
{
    [Inject] ProxyBetweenScenes proxyBetweenScenes;
    public List<DeckTile> choosenTiles=new List<DeckTile>();
    public List<DeckTile> unchoosenTiles=new List<DeckTile>();
    public List<GameObject> units=new List<GameObject>{};
    public void Choose(DeckTile tile)
    {   
        GameObject unit=tile.GetObject();
        if (choosenTiles.Contains(tile))
        {
            foreach (DeckTile _tile in unchoosenTiles)
            {
                if (_tile.tileObject == null)
                {
                    _tile.SetObject(unit);
                    return;
                }
            }
            tile.SetObject(unit);
        } else
        {
            foreach (DeckTile _tile in choosenTiles)
            {
                if (_tile.tileObject == null)
                {
                    _tile.SetObject(unit);
                    return;
                }
            }
            tile.SetObject(unit);
        }
    }
    public bool SaveDeck()
    {
        
        foreach (DeckTile _tile in choosenTiles)
            {
                if (_tile.tileObject == null)
                {
                    return false;
                } else
                {
                    units.Add(_tile.tileObject.GetComponent<UnitTile>().unit);
                }
            }
        return true;
    }   
}
