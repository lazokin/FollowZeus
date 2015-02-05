using UnityEngine;
using System.Collections.Generic;
using System;

public class StateActionPreyFollow : StateActionPreyDontEvade
{
    SteeringBehavior steeringBehaviour;
    private float breakFollowDistance;
    private float safeZoneSprintDistance;
    protected GameObject[] safeZoneArray;
    private LevelData levelData;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        steeringBehaviour = gameObject.GetComponent<SteeringBehavior>();
        breakFollowDistance = gameObject.GetComponent<PreyController>().BreakFollowDistance;
        safeZoneSprintDistance = gameObject.GetComponent<PreyController>().SafeZoneSprintDistance;
        levelData = GameObject.Find("Level Manager").GetComponent<LevelData>();

        return this;
    }

    public override void Execute()
    {
        base.Execute();

        steeringBehaviour.target = player.transform;
        steeringBehaviour.currentState = SteeringBehavior.AIState.Seek;

        float distanceToPlayer = (gameObject.transform.position - player.transform.position).magnitude;
        if (distanceToPlayer > breakFollowDistance)
        {
            transitions ["Follow->Hold"].IsTriggered = true;
        }

        safeZoneArray = levelData.SafeZoneArray;
        foreach (GameObject safeZone in safeZoneArray)
        {
            float distanceToSafeZone = (gameObject.transform.position - safeZone.transform.position).magnitude;
            if (distanceToSafeZone < safeZoneSprintDistance)
            {
                transitions ["Follow->SafeZone"].IsTriggered = true;
                break;
            }
        }
    }

    #endregion


}
