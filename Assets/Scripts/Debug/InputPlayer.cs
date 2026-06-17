using System;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using VContainer;
public class InputPlayer : MonoBehaviour,IInputReciever
{
    [Inject] GameUnitsFactory factory;
    [Inject] BoardManager manager;
    [Inject] GameManager gameManager;
    [Inject] GameData data;
    [Inject] Camera cam;
    public LayerMask layerMask;
    public GameObject unitF;
    public GameObject unitE;
    public GameObject carriedUnit;
    public void OnClickUp(Vector2 screenPosition)
    {
        if (gameManager.condition==GameCondition.Choosing)
        {
            if (carriedUnit != null)
                {
                NavMeshAgent agent=carriedUnit.GetComponent<NavMeshAgent>();
                Ray ray = cam.ScreenPointToRay(screenPosition);
                if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, layerMask))
                {    
                    if (!manager.PutUnit(hit.collider.gameObject.GetComponent<FloorSegment>(), carriedUnit))
                    {
                        manager.CancelPutting();
                        agent.enabled=true;
                        agent.updatePosition=true;
                        agent.updateRotation=true;
                    } else
                    {
                        agent.enabled=true;
                        agent.updatePosition=true;
                        agent.updateRotation=true;
                    }
                   
                } else
                    {
                        manager.CancelPutting();
                        agent.enabled=true;
                    }
                }
                carriedUnit = null;
        }
    }
    public void OnClickDown(Vector2 screenPosition)
    {
        if (gameManager.condition==GameCondition.Choosing)
        {
            Ray ray = cam.ScreenPointToRay(screenPosition);
                if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, layerMask))
                {
                    var objHit=hit.collider.gameObject;
                    FloorSegment segment=objHit.GetComponent<FloorSegment>();
                    GameObject unit=segment.unit;
                    if (unit!=null){
                    if (manager.TakeUnit(segment, unit))
                        {
                            NavMeshAgent agent=unit.GetComponent<NavMeshAgent>();
                            agent.enabled=false;
                            agent.updatePosition=false;
                            agent.updateRotation=false;
                            carriedUnit=unit;
                        }                
                    }
                }
        }
    }
    public void OnPointerMoved(Vector2 screenPosition, bool isPressed)
    {
        if (gameManager.condition==GameCondition.Choosing)
        {
            if (isPressed)
            {
                Ray ray = cam.ScreenPointToRay(screenPosition);
                if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, layerMask))
                {
                    if (carriedUnit != null)
                    {
                        carriedUnit.transform.position=hit.point;
                    }
                }
            }
                
        }
    }
    void Update()
    {
        /*if (gameManager.condition==GameCondition.Choosing)
            {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, layerMask))
                {
                    var objHit=hit.collider.gameObject;
                    FloorSegment segment=objHit.GetComponent<FloorSegment>();
                    GameObject unit=segment.unit;
                    if (unit!=null){
                    if (manager.TakeUnit(segment, unit))
                        {
                            NavMeshAgent agent=unit.GetComponent<NavMeshAgent>();
                            agent.enabled=false;
                            agent.updatePosition=false;
                            agent.updateRotation=false;
                            carriedUnit=unit;
                        }                
                    }
                }
            }
            if (Input.GetMouseButton(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, layerMask))
                {
                    if (carriedUnit != null)
                    {
                        carriedUnit.transform.position=hit.point;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (carriedUnit != null)
                {
                NavMeshAgent agent=carriedUnit.GetComponent<NavMeshAgent>();
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, layerMask))
                {    
                    if (!manager.PutUnit(hit.collider.gameObject.GetComponent<FloorSegment>(), carriedUnit))
                    {
                        manager.CancelPutting();
                        agent.enabled=true;
                        agent.updatePosition=true;
                        agent.updateRotation=true;
                    } else
                    {
                        agent.enabled=true;
                        agent.updatePosition=true;
                        agent.updateRotation=true;
                    }
                   
                } else
                    {
                        manager.CancelPutting();
                        agent.enabled=true;
                    }
                }
                carriedUnit = null;
            }
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity, layerMask))
                {
                    var segment=hit.collider.gameObject.GetComponent<FloorSegment>();
                    if (segment.unit == null)
                    {
                        GameObject unit = factory.SpawnUnit(unitE, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation,false);
                        segment.SetObject(unit);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                data.blueChooseEnd=true;
            }
        }*/
    }
}