using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Arrive))]
public class FollowCircularPath : MonoBehaviour
{
    public interface FollowCircularPathEventListener
    {
        void DestinationReached();
    }

    private FollowCircularPathEventListener listener = null;

    public float nodeArrivalDistance = 1;

    private Arrive arrive;
    private Path path;
    private int nextNodeIdx;

    void Start()
    {
        arrive = GetComponent<Arrive>();
    }

    public void SetPath(Path path)
    {
        this.path = path;
        if (path.Length == 1)
        {
            nextNodeIdx = 0;
        } else
        {
            nextNodeIdx = 1;
        }
    }

    public void CancelPath()
    {
        this.path = null;
    }

    public Vector3 LinearAcceleration()
    {
        if (path == null)
        {
            return Vector3.zero;
        }
        Vector3 nextTargetPosition = NextTargetPositionAlongPath();
        return arrive.LinearAcceleration(nextTargetPosition);
    }

    public Vector3 AngularAcceleration()
    {
        return Vector3.zero;
    }

    private Vector3 NextTargetPositionAlongPath()
    {
        float distancetoNextNode = (path.GetPosition(nextNodeIdx) - transform.position).magnitude;
        if (distancetoNextNode < nodeArrivalDistance)
        {
            nextNodeIdx++;
            if (nextNodeIdx == path.Length)
            {
                nextNodeIdx = 0;
                if (listener != null)
                {
                    listener.DestinationReached();
                }
            }
        }
        return path.GetPosition(nextNodeIdx);

    }

    public void ListenForEvents(FollowCircularPathEventListener listener)
    {
        this.listener = listener;
    }

}
