using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerControl : MonoBehaviour
{
    RaycastHit HitInfo = new RaycastHit();

    NavMeshAgent agent;
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetMousePoint();
	}
    void GetMousePoint()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out HitInfo))
            {
                Collider[] coliders = Physics.OverlapSphere(HitInfo.point, 3);
                if(coliders.Length!=0)
                {
                    for(int i=0;i<coliders.Length;i++)
                    {
                        if(coliders[i].transform.tag=="Enemy")
                        {
                            agent.Warp(coliders[i].transform.position);
                        }    
                    }           
                    agent.destination = HitInfo.point;
                }
                else
                {
                    agent.destination = HitInfo.point;
                    Debug.Log("111");
                }
                
            }

        }
    }
}
