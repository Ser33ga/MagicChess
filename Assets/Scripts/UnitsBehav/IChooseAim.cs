using UnityEngine;
using System.Collections.Generic;
using System;
public interface IChooseAim
{
    public GameObject FindAim(Vector3 fromPosition, List<GameObject> candidates, Predicate<GameObject> priority);
}
public class BaseChooserAim : IChooseAim
{
    public GameObject FindAim(Vector3 fromPosition, List<GameObject> candidates, Predicate<GameObject> priority)
    {
        if (candidates.Count==0)
        return null;
        GameObject aim=null;
        GameObject priorityAim=null;
        float dest=float.MaxValue;
        float destToPriority=float.MaxValue;
        foreach(GameObject unit in candidates)
        {
            float dist=Vector3.Distance(fromPosition, unit.transform.position);
            if (priority(unit))
            {
                if (dist < destToPriority)
                {
                    destToPriority=dist;
                    priorityAim=unit;
                }
            }
            else
            {
                if (dist < dest)
                {
                    dest =dist;
                    aim=unit;
                }
            }
        }
        if (priorityAim != null)
        {
            return priorityAim;
        } else
        {
            return aim;
        }
    }
}