using System.Collections.Generic;
using System;
using UnityEngine;

public class TickSystem : MonoBehaviour
{
    private List<TickTask> TickTasks=new(){};
    public class TickTask
    {
        public Action Method;
        public float NeedTime;
        public float NextTime;
        public bool canceled;
    }
    void Update()
    {
        for(int i=TickTasks.Count-1; i>=0;i-=1)
        {
            TickTask task=TickTasks[i];
            if (task.canceled!=true){
            if (Time.time >= task.NextTime)
            {
                if (task.Method != null)
                    {
                        task.Method();
                        task.NextTime=Time.time+task.NeedTime;
                    }
            }
            } else
            {
                TickTasks.RemoveAt(i);
            }
        }
    }
    public TickTask AddToTasks(Action method, float needTime)
    {
        TickTask handle=new TickTask {Method=method,NeedTime=needTime,NextTime=Time.time+needTime, canceled=false};
        TickTasks.Add(handle);
        return handle;
    }
    public void DeleteFromTasks(TickTask handle)
    {
        handle.canceled=true;
    }
}

