using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Arrive))]
public class FollowLinearCyclePath : MonoBehaviour
{
    public interface FollowLinearCyclePathEventListener
    {
        void MovingForward();
        void MovingBackward();
    }

    private FollowLinearCyclePathEventListener listener = null;

    public float nodeArrivalDistance = 1;

    private Arrive arrive;
    private Path path;
    private int nextNodeIdx;
    private bool movingForward = true;

    void Start()
    {
        arrive = GetComponent<Arrive>();
    }

    public void SetPath(Path path)
    {
        this.path = path;
        movingForward = true;
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
            if (movingForward)
            {
                nextNodeIdx++;
                if (nextNodeIdx == path.Length)
                {
                    nextNodeIdx = path.Length - 1;
                    if (listener != null)
                    {
                        listener.MovingBackward();
                    }
                    movingForward = false;
                }
            } else
            {
                nextNodeIdx--;
                if (nextNodeIdx < 0)
                {
                    nextNodeIdx = 1;
                    if (listener != null)
                    {
                        listener.MovingForward();
                    }
                    movingForward = true;
                }
            }


        }
        return path.GetPosition(nextNodeIdx);

    }

    public void ListenForEvents(FollowLinearCyclePathEventListener listener)
    {
        this.listener = listener;
    }

}
