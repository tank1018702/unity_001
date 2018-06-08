using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameover;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            gameover.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
