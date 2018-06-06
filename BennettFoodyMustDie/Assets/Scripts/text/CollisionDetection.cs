using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool IsCollision=false;

    private void OnCollisionEnter(Collision collision)
    {
        IsCollision = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        IsCollision = false;
    }

    private void Update()
    {
        Debug.Log(IsCollision);
    }

}
