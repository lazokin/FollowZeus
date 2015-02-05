    using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Arrive))]
public class FollowLinearPath : MonoBehaviour
{
    public interface FollowLinearPathEventListener
    {
        void DestinationReached();
    }

    private FollowLinearPathEventListener listener = null;

    public float nodeArrivalDistance = 1;

    private Arrive arrive;
    private Path path;
    private int nextNodeIdx;
    private bool destinationReached = false;

    void Start()
    {
        arrive = GetComponent<Arrive>();
    }

    public void SetPath(Path path)
    {
        this.path = path;
        destinationReached = false;
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
                nextNodeIdx--;
                if (destinationReached == false)
                {
                    destinationReached = true;
                    if (listener != null)
                    {
                        listener.DestinationReached();
                    }
                }
            }
        }
        return path.GetPosition(nextNodeIdx);

    }

    public void ListenForEvents(FollowLinearPathEventListener listener)
    {
        this.listener = listener;
    }

}
