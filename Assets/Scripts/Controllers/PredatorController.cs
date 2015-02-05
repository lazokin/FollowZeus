using UnityEngine;
using System.Collections;

public class PredatorController : MonoBehaviour
{
    private Path patrolPath;
    public Path PatrolPath
    {
        get
        {
            return patrolPath;
        }
    }

    public bool startInPatrol;
    public bool StartInPatrol
    {
        get
        {
            return startInPatrol;
        }
    }

    public Vector3[] patrolPoints;
    public Vector3[] PatrolPoints
    {
        get
        {
            return patrolPoints;
        }
    }

    private Vector3 homePosition;
    public Vector3 HomePosition
    {
        get
        {
            return homePosition;
        }
    }

    public float startPursuitDistance = 1;
    public float StartPursuitDistance
    {
        get
        {
            return startPursuitDistance;
        }
    }

    public float breakPursuitDistance = 1;
    public float BreakPursuitDistance
    {
        get
        {
            return breakPursuitDistance;
        }
    }
    
    public float startAttackDistance = 1;
    public float StartAttackDistance
    {
        get
        {
            return startAttackDistance;
        }
    }

    public float breakAttackDistance = 1;
    public float BreakAttackDistance
    {
        get
        {
            return breakAttackDistance;
        }
    }

    public float pathPlanningUpdateTime = 1;
    public float PathPlanningUpdateTime
    {
        get
        {
            return pathPlanningUpdateTime;
        }
    }

    public float stunnedTimeout = 1;
    public float StunnedTimeout
    {
        get
        {
            return stunnedTimeout;
        }
    }

    private LevelData levelData;
    
    // Use this for initialization
    void Awake()
    {
        homePosition = transform.position;
        patrolPath = new Path();
        foreach (Vector3 point in PatrolPoints)
        {
            PatrolPath.AddPosition(point);
        }
    }

    void Start()
    {
        levelData = GameObject.Find("Level Manager").GetComponent<LevelData>();
    }

    void OnDestroy()
    {
        levelData.PredatorArray = GameObject.FindGameObjectsWithTag("Predator");
    }

}