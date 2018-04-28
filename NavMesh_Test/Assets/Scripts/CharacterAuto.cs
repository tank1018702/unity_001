using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class CharacterAuto : MonoBehaviour
{


    NavMeshAgent _agent;



  

    public void SetTarget(Vector3 waypoint)
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(waypoint);
    }



}
