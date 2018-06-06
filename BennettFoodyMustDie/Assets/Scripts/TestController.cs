using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{

    Rigidbody2D rig;



    void Start()
    {
        rig = transform.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (pos-transform.position).normalized;



        

        Vector2 dir2 = (Camera.main.WorldToScreenPoint(Input.mousePosition) - transform.position).normalized;



        Debug.Log(dir);

        Debug.Log(Input.mousePosition);

        Debug.DrawRay(transform.position, dir, Color.red);

        //Debug.DrawLine(transform.position, Input.mousePosition,Color.yellow);

        //Debug.DrawLine(transform.position, (Camera.main.WorldToScreenPoint(Input.mousePosition) - transform.position), Color.white);
        if (Input.GetMouseButtonDown(0))
        {

            rig.AddForce(dir * 100000, ForceMode2D.Force);
        }

    }
}
