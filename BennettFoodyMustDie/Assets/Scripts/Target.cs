using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

	

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        Vector2 mouseposition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseposition;
    }
}
