using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalController : MonoBehaviour
{
    public float MaxDistance;

    float RelativeDistance;

    float Mouse_CurrentDistance;

    float Body_CurrentDistance;

    Vector3 Confined_MousePosition;

    public GameObject Hammer;

    public GameObject Body;

    public GameObject MouseTarget;


    Rigidbody2D hammer_rig;

    Rigidbody2D body_rig;

    bool Hammer_IsCollision;

    void Start()
    {
        hammer_rig = Hammer.GetComponent<Rigidbody2D>();

        body_rig = Body.GetComponent<Rigidbody2D>();

    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        Rigidbody2D temp_rig;
        Hammer_IsCollision = Hammer.transform.GetComponent<Trigger>().iscollision;

        Mouse_CurrentDistance = Vector3.Distance(MouseTarget.transform.position, Body.transform.position);
        Body_CurrentDistance = Vector3.Distance(Hammer.transform.position, Body.transform.position);

        RelativeDistance = Vector3.Distance(MouseTarget.transform.position, Body.transform.position);



        if (RelativeDistance > MaxDistance)
        {
            Confined_MousePosition = (MouseTarget.transform.position - Body.transform.position).normalized * MaxDistance + Body.transform.position;
        }
        else
        {
            Confined_MousePosition = MouseTarget.transform.position;
        }


        hammer_rig.velocity = (Confined_MousePosition - Hammer.transform.position) * 10;

        if (Hammer_IsCollision)
        {
            
            body_rig.velocity = -(Confined_MousePosition - Hammer.transform.position) * 10;
            //if (body_rig.velocity.magnitude < 0.1)
            //{
            //    body_rig.velocity = -(Confined_MousePosition - Hammer.transform.position) * 5;
            //    body_rig.AddForce(-(Confined_MousePosition - Hammer.transform.position) * 10, ForceMode2D.Impulse);
            //}

        }

        Debug.DrawRay(Hammer.transform.position, hammer_rig.velocity, Color.red);
        Debug.DrawRay(Body.transform.position, body_rig.velocity);



        //if (Hammer_IsCollision)
        //{
        //    temp_rig = body_rig;

        //}
        //else
        //{
        //    temp_rig = hammer_rig;

        //}

        //if (Body_CurrentDistance <= MaxDistance||Mouse_CurrentDistance<MaxDistance)
        //{

        //    temp_rig.velocity=temp_rig==body_rig? -(MouseTarget.transform.position - Hammer.transform.position) * 5: (MouseTarget.transform.position - Hammer.transform.position) * 5;

        //}
        //else
        //{
        //    temp_rig.velocity = Vector3.zero;
        //}




        //Debug.Log(CurrentDistance);
    }
}
