using UnityEngine;
using System.Collections;

public class Seek : MonoBehaviour
{
    public float maxAcceleration = 1f;

    private Vector3 direction = new Vector3();
    private Vector3 linearAcceleration = new Vector3();

    public Vector3 LinearAcceleration(Vector3 target)
    {
        direction = target - transform.position;
        linearAcceleration = direction.normalized * maxAcceleration;
        return linearAcceleration;
    }

    public Vector3 AngularAcceleration(Vector3 target)
    {
        return Vector3.zero;
    }
}
