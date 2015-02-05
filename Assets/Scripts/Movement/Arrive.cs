using UnityEngine;
using System.Collections;

public class Arrive : MonoBehaviour
{
    public float maxAcceleration = 1f;
    public float slowRadius = 1f;
    public float timeToTarget = 0.1f;

    private float maxSpeed;
    private Vector3 direction = new Vector3();
    private Vector3 linearAcceleration = new Vector3();
    private Vector3 targetVelocity = new Vector3();
    private float distance;
    private float targetSpeed;

    public Vector3 LinearAcceleration(Vector3 target)
    {
        maxSpeed = GetComponent<MovementController>().maxLinearSpeed;

        direction = target - transform.position;
        distance = direction.magnitude;

        if (distance > slowRadius)
        {
            targetSpeed = maxSpeed;
        } else
        {
            targetSpeed = maxSpeed * (distance / slowRadius);
        }

        targetVelocity = direction.normalized * targetSpeed;

        linearAcceleration = (targetVelocity - rigidbody.velocity) / timeToTarget;
        if (linearAcceleration.magnitude > maxAcceleration)
        {
            linearAcceleration = linearAcceleration.normalized * maxAcceleration;
        }

        return linearAcceleration;
    }

    public Vector3 AngularAcceleration(Vector3 target)
    {
        return Vector3.zero;
    }

}
