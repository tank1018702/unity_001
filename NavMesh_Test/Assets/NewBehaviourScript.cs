using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject cube;
    float[] audioStaus = new float[64];
    List<GameObject> objs = new List<GameObject>();
    Vector3 center;
	void Start ()
    {
        center = transform.forward;
        for (int i=0;i<64;i++)
        {
            var tmpCube = Instantiate(cube, center, Quaternion.identity);
            objs.Add(tmpCube);
            center+= transform.forward*0.1f;
        }	
	}
	
	// Update is called once per frame
	void Update ()
    {
        AudioListener.GetSpectrumData(audioStaus,0,FFTWindow.BlackmanHarris);
        for (int i=0;i<objs.Count;i++)
        {
            objs[i].transform.position = new Vector3(objs[i].transform.position.x, audioStaus[i]*30.0f, objs[i].transform.position.z);
        }
	}
}
