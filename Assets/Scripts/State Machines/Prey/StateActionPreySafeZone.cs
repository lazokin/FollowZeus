using UnityEngine;
using System.Collections.Generic;

public class StateActionPreySafeZone : StateAction
{
    SteeringBehavior steeringBehaviour;
    private float safeZoneSprintDistance;
    protected GameObject[] safeZoneArray;
    private GameObject target;
    private LevelData levelData;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        steeringBehaviour = gameObject.GetComponent<SteeringBehavior>();
        safeZoneSprintDistance = gameObject.GetComponent<PreyController>().SafeZoneSprintDistance;
        levelData = GameObject.Find("Level Manager").GetComponent<LevelData>();

        return this;
    }

    public override void Execute()
    {
        safeZoneArray = levelData.SafeZoneArray;
        target = null;
        foreach (GameObject safeZone in safeZoneArray)
        {
            float distanceToSafeZone = (gameObject.transform.position - safeZone.transform.position).magnitude;
            if (distanceToSafeZone < safeZoneSprintDistance)
            {
                target = safeZone;
            }
        }

        if (target == null)
        {
            transitions ["SafeZone->Follow"].IsTriggered = true;
        } else
        {
            steeringBehaviour.target = target.transform;
            steeringBehaviour.currentState = SteeringBehavior.AIState.Arrive;
        }
    }

    #endregion


}
