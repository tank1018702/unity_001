using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool iscollision;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        iscollision = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        iscollision = false;
    }
}
