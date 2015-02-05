using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    public float maxLinearSpeed = 1f;
    public float maxAngularSpeed = 1f;

    public void Move(Vector3 linearAcceleration, Vector3 angularAcceleration)
    {

        rigidbody.velocity = rigidbody.velocity + linearAcceleration * Time.deltaTime;
        if (rigidbody.velocity.magnitude > maxLinearSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxLinearSpeed;
        }

        rigidbody.angularVelocity = rigidbody.angularVelocity + angularAcceleration * Time.deltaTime;
        if (rigidbody.angularVelocity.magnitude > maxAngularSpeed)
        {
            rigidbody.angularVelocity = rigidbody.angularVelocity.normalized * maxAngularSpeed;
        }
    }
}
