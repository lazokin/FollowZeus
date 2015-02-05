using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class KineticDrive : MonoBehaviour
{
    public float maxAcceleration = 10.0f;
    public float maxVelocity = 5.0f;
    
    public void Drive(Vector3 direction)
    {
        direction.Normalize();

        Vector3 targetVelocity = direction * maxVelocity;

        Vector3 acceleration = (targetVelocity - rigidbody.velocity) * maxAcceleration;

        if (acceleration.magnitude > maxAcceleration)
        {
            acceleration = acceleration.normalized * maxAcceleration;
        }
        
        rigidbody.velocity += acceleration * Time.deltaTime;

    }
}
