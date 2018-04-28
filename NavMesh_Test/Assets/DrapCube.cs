using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrapCube : MonoBehaviour
{

    public GameObject TargetCube;

    public GameObject MainCamera;
    Vector2 LastScreenMousePos;
    Vector2 CurrentMousePos;
    public float rotatespeed;
    float xDeg;
    float yDeg;
    public float xSpeed;
    public float ySpeed;

    Vector3 MousePosition_start;
    Vector3 MousePosition_end;

    NavMeshSurface[] surfacelist;



    void Start()
    {
        surfacelist = TargetCube.transform.GetComponentsInChildren<NavMeshSurface>();
    }

    void SurfacesControl(bool tirgger)
    {

        for (int i = 0; i < surfacelist.Length; i++)
        {
            surfacelist[i].enabled = tirgger;
        }
    }


    void Update()
    {
        MousePosition_start = Input.mousePosition;

      
        if (Input.GetKey(KeyCode.Mouse1))
        {

            Vector3 MouseDirction = (MousePosition_end - MousePosition_start).normalized;
            MainCamera.transform.RotateAround(TargetCube.transform.position, Vector3.Cross(-transform.forward, MouseDirction), rotatespeed  * Time.deltaTime);
            MousePosition_end = MousePosition_start;

            //TargetCube.transform.RotateAround(TargetCube.transform.position,Vector3.forward, 180 * Time.deltaTime);




            //xDeg += Input.GetAxis("Mouse X");
            //yDeg -= Input.GetAxis("Mouse Y");
            //Vector3 MouseDirection = new Vector3(xDeg, yDeg,0).normalized;
            //Vector3 rotateAxis = Vector3.Cross(MouseDirection, TargetCube.transform.forward);
            //TargetCube.transform.Rotate(rotateAxis, rotatespeed * Time.deltaTime);
            //  yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);
            //TargetCube.transform.rotation *= Quaternion.Euler(yDeg,- xDeg, 0);
            // CurrentMousePos = Input.mousePosition;
            //var mouseScroll = Input.mouseScrollDelta;
            //var mouseScroll = Input.mouseScrollDelta;

        }
        else
        {
            MousePosition_end = Input.mousePosition;
        }

    }



}
