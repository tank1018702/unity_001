using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incubator : MonoBehaviour
{
    public GameObject Agent;

    public GameObject Target;

    public float BornTime;

    Vector3 BornPoint;
	
	void Start ()
    {
        BornPoint = transform.GetChild(0).transform.position;

        StartCoroutine(OverAndOver());
	}
	

    IEnumerator OverAndOver()
    {
        while(true)
        {
           GameObject go= Instantiate(Agent, BornPoint, Quaternion.identity);
            go.GetComponent<CharacterAuto>().SetTarget(Target.transform.position);
            
            yield return new WaitForSeconds(BornTime);
        }
    }		
}
