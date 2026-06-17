using UnityEngine;
public interface IMove
{
    public void Move(Vector3 destination);
    public void Stop();
    public void ToMove();
    public void Initialize(UnityEngine.AI.NavMeshAgent _agent,float speed);
}
public class BaseMover : IMove
{
    private UnityEngine.AI.NavMeshAgent agent;
    public void Initialize(UnityEngine.AI.NavMeshAgent _agent,float speed)
    {
        agent=_agent;
        agent.speed=speed;
    }
    public void Move(Vector3 destination)
    {
        if(agent!=null && agent.enabled==true && agent.isOnNavMesh)
        agent.destination=destination;  
    }
    public void Stop()
    {
        if(agent!=null && agent.enabled==true && agent.isOnNavMesh)
        agent.isStopped=true;  
    }
    public void ToMove()
    {
        if(agent!=null && agent.enabled==true && agent.isOnNavMesh)
        agent.isStopped=false;
    }
}