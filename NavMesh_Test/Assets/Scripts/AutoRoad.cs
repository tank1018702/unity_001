using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutoRoad : MonoBehaviour
{
    public GameObject road;

    NavMeshSurface surface;

    void Start()
    {
        surface = transform.GetComponent<NavMeshSurface>();

        StartCoroutine(auto_road());
    }


    void Update()
    {

    }

    IEnumerator auto_road()
    {
        while(true)
        {
            //road.transform.Rotate(road.transform.up, 90);

            yield return RoadRotate(90, 1f);
            //surface.BuildNavMesh();
            yield return new WaitForSeconds(5);
        }
        
    }

    IEnumerator RoadRotate(float angle,float time)
    {
        while(time>=0)
        {
            float mintime = 0.01f;
            road.transform.Rotate(road.transform.up, Mathf.Min(mintime / time * angle, angle));
            angle -= mintime / time * angle;
            time -= mintime;
            //surface.BuildNavMesh();
            yield return new WaitForSeconds(mintime);
        }
        
    }
}
