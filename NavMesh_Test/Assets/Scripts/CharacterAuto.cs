using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterAuto : MonoBehaviour
{


    NavMeshAgent _agent;

    Vector3 _waypoint=Vector3.zero;

  

    public void SetTarget(Vector3 waypoint)
    {
        _agent = GetComponent<NavMeshAgent>();
        _waypoint = waypoint;
        _agent.SetDestination(waypoint);
    }
    private void Update()
    {
        if(_waypoint!=Vector3.zero)
        {
            if(_agent.isOnNavMesh)
            {
                _agent.SetDestination(_waypoint);
            }
        }
    }



}
