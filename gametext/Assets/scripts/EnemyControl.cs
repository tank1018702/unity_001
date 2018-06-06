using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControl : MonoBehaviour {

    NavMeshAgent agent;

    Vector3 temple_point;
    public GameObject floor;


	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(GoTheRounds());
	}
	
	
	void Update ()
    {
        
	}

    IEnumerator GoTheRounds()
    {
        while(true)
        {
            var random_point = Random.insideUnitCircle * 50;
            temple_point = new Vector3(random_point.x + floor.transform.position.x, +floor.transform.position.y , random_point.y +floor.transform.position.z);
            agent.SetDestination(temple_point);
            yield return new WaitForSeconds(2f);
        }
        
    }
}
