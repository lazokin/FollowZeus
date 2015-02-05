using UnityEngine;
using System.Collections.Generic;

public class StateActionPreyHold : StateActionPreyDontEvade
{
    SteeringBehavior steeringBehaviour;
    private float startFollowDistance;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        steeringBehaviour = gameObject.GetComponent<SteeringBehavior>();
        startFollowDistance = gameObject.GetComponent<PreyController>().StartFollowDistance;

        return this;
    }

    public override void Execute()
    {
        base.Execute();

        steeringBehaviour.target = null;
        steeringBehaviour.currentState = SteeringBehavior.AIState.Idle;

        float distanceToPlayer = (gameObject.transform.position - player.transform.position).magnitude;
        if (distanceToPlayer < startFollowDistance)
        {
            transitions ["Hold->Follow"].IsTriggered = true;
        }
    }

    #endregion


}
