using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterControl : MonoBehaviour
{
    NavMeshAgent _agent;
    RaycastHit _HitInfo = new RaycastHit();

    public GameObject temppoint;

	
	void Start ()
    {
        _agent = GetComponent<NavMeshAgent>();
        
    }
	
	
	void Update ()
    {
        
        GetMousePoint();
        //CloseDiscoverd();
        CompleteImmediately();
        //_agent.CalculatePath()
        //RayCast_Test();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _agent.Warp(temppoint.transform.position);
        }
    }

    void GetMousePoint()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin,ray.direction,out _HitInfo))
            {
                _agent.destination = _HitInfo.point;
            }

        }
    }

    void CloseDiscoverd()
    {
        if(_agent.isOnOffMeshLink)
        {
            _agent.ActivateCurrentOffMeshLink(false);
        }
    }
    
    void RayCast_Test()
    {
        NavMeshHit hit;
        if(_agent.Raycast(_HitInfo.point, out hit))
        {
            //Debug.Log(hit.distance);
        }
        
    }


    void CompleteImmediately()
    {
        if (_agent.isOnOffMeshLink)
        {
            
            _agent.CompleteOffMeshLink();
            
        }
    }
    void OpenDiscoveredArea(Hashtable areasDiscovered)
    {
        if (_agent.isOnOffMeshLink)
            if (areasDiscovered.ContainsKey(_agent.currentOffMeshLinkData.offMeshLink.name))
                _agent.ActivateCurrentOffMeshLink(true);


    }
}
