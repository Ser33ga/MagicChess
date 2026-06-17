using System.Collections.Generic;
using UnityEngine;

public class ProjectileManage : MonoBehaviour
{
    public GameObject proj;
    public List<GameObject> unactiveProjectiles=new List<GameObject>{};
    public List<GameObject> activeProjectiles=new List<GameObject>{};

    public void CreatePool()
    {
        for (int i=0; i<5; i++)
        {
            GameObject _proj=Instantiate(proj, transform.position, transform.rotation);
            _proj.transform.SetParent(gameObject.transform);
            _proj.GetComponent<Projectile>().data=GetComponent<UnitData>();
            unactiveProjectiles.Add(_proj);
            _proj.SetActive(false);
        }
    }
    public void AddToActivePool(GameObject _proj)
    {
        _proj.SetActive(true);
        activeProjectiles.Add(_proj);
        unactiveProjectiles.Remove(_proj);
    }
    public void AddToUnActivePool(GameObject _proj)
    {
        activeProjectiles.Remove(_proj);
        unactiveProjectiles.Add(_proj);
        _proj.transform.position=transform.position;
        _proj.SetActive(false);
    }
    public GameObject CreateProjectile()
    {
        GameObject _proj=unactiveProjectiles[0];
        AddToActivePool(unactiveProjectiles[0]);
        return _proj;
    }
    public void RemoveProjectile(GameObject proj)
    {
        AddToUnActivePool(proj);
    }
}
