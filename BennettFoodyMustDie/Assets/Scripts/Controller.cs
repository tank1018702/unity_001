using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject body;

    public GameObject fpoint;

    public GameObject target;


    Vector2 ForcePoint;

    


    Vector2 contactpoint=Vector2.zero;

    Rigidbody rig;

    HingeJoint2D hinge;

    


    public float MoveSpeed;

    

    void Start()
    {
        rig = transform.GetComponent<Rigidbody>();

        ForcePoint = fpoint.transform.position;
    }


    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    rigidbody.AddForce(new Vector2(0, -1) * 400,ForceMode2D.Impulse);


        //if (Input.GetMouseButton(0))
        {
            //Collider2D [] colliders=Physics2D.ovel

            //Debug.Log(contactpoint);



            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

            Vector3 dir2 /*= (new Vector2(point.x, point.y) - new Vector2(transform.position.x, transform.position.y));*/
                         //= (new Vector2(target.transform.position.x, target.transform.position.y) - new Vector2(transform.position.x, transform.position.y));
                           = target.transform.position - transform.position;
                          
            


            float sqr_distance = (new Vector2(point.x, point.y) - new Vector2(body.transform.position.x, body.transform.position.y)).sqrMagnitude;

            float local_sqr_distance = (new Vector2(transform.position.x, transform.position.y) - new Vector2(body.transform.position.x, body.transform.position.y)).sqrMagnitude;

            MoveSpeed = Vector3.Distance(transform.position, new Vector3(dir2.x, dir2.y, 0));

            //fpoint.GetComponent<Rigidbody2D>().velocity = dir2 * MoveSpeed;

            if(Vector2.Distance( fpoint.transform.position,point)>=0.5f)
            {
                fpoint.GetComponent<Rigidbody>().velocity = dir2 * 5;
                //rig.velocity = dir2 * 5;

                Debug.Log(dir2);
            }
            else
            {
                fpoint.GetComponent<Rigidbody>().velocity = Vector2.zero;
            }
            
            //rig.velocity = dir2*5;

            



            //if (MoveSpeed >= 0.2f)
            //{
            //    fpoint.transform.position += new Vector3(dir2.x, dir2.y, 0) * MoveSpeed * 2 * Time.deltaTime;
            //}
            //else
            //{
            //   fpoint. transform.position = new Vector3(point.x, point.y, 0);

            //}
            //Debug.Log("mouse:"+sqr_distance);

            //Debug.Log("local:" + local_sqr_distance);



            //if(sqr_distance<=9)
            //{
            //    transform.position =  new Vector3(point.x,point.y,0);
            //}
            //else
            //{
            //    transform.position = body.transform.position + dir *5.5f;
            //}
            //transform.up = dir2;


            //Debug.DrawRay(transform.position, dir2, Color.red);


            //transform.Translate(dir.x, dir.y, 0);






            //rig.velocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * 2;


            //rig.AddForce(dir * 10, ForceMode2D.Force);

            //float angle = Vector3.Angle(transform.up, dir);
            //transform.up = (Input.mousePosition - transform.position).normalized;
            //transform.Rotate(Vector3.Cross(transform.up, dir), angle);

            //Debug.Log(Input.mousePosition);



        }

        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D cp = collision.contacts[0];

        contactpoint = cp.point;
    }

}
