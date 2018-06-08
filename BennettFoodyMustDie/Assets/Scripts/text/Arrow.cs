using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public Transform target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.up = (new Vector3(target.position.x, target.position.y, transform.position.z) - transform.position).normalized;
    }
}
