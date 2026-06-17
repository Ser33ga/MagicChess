using System.Collections.Generic;
using UnityEngine;
public class UnitsPool
{
    public List<GameObject> friendlyUnits=new List<GameObject>{};
    public List<GameObject> enemyUnits=new List<GameObject>{};
    public List<GameObject> deadUnits=new List<GameObject>{};
    public void AddToFriendly(GameObject unit)
    {
        friendlyUnits.Add(unit);
    }
    public void RemoveFromFriendly(GameObject unit)
    {
        friendlyUnits.Remove(unit);
    }
    public void AddToEnemy(GameObject unit)
    {
        enemyUnits.Add(unit);
    }
    public void RemoveFromEnemy(GameObject unit)
    {
        enemyUnits.Remove(unit);
    }
    public void AddToDead(GameObject unit)
    {
        deadUnits.Add(unit);
    }
    public void RemoveFromDead(GameObject unit)
    {
        deadUnits.Remove(unit);
    }
}