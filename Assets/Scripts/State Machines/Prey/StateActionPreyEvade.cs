using UnityEngine;
using System.Collections.Generic;

public class StateActionPreyEvade : StateAction
{
    SteeringBehavior steeringBehaviour;
    private float breakEvadeDistance;
    private GameObject[] predatorArray;
    private GameObject target;
    private LevelData levelData;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        steeringBehaviour = gameObject.GetComponent<SteeringBehavior>();
        breakEvadeDistance = gameObject.GetComponent<PreyController>().BreakEvadeDistance;
        levelData = GameObject.Find("Level Manager").GetComponent<LevelData>();

        return this;
    }

    public override void Execute()
    {
        predatorArray = levelData.PredatorArray;
        target = null;
        foreach (GameObject predator in predatorArray)
        {
            float distanceToPredator = (gameObject.transform.position - predator.transform.position).magnitude;
            if (distanceToPredator < breakEvadeDistance)
            {
                target = predator;
            }
        }

        if (target == null)
        {
            transitions ["Evade->Hold"].IsTriggered = true;
        } else
        {
            steeringBehaviour.target = target.transform;
            steeringBehaviour.currentState = SteeringBehavior.AIState.Flee;
        }

    }

    #endregion


}
