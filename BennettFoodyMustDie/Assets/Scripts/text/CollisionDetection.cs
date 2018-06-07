using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool IsCollision=false;

    public Vector3 velocity;

    private void OnCollisionEnter(Collision collision)
    {
        velocity = collision.relativeVelocity;
        IsCollision = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        IsCollision = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        IsCollision = false;
    }

    private void Update()
    {
        
    }

}
