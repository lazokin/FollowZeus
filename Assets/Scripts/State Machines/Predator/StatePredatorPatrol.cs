using UnityEngine;
using System.Collections.Generic;

public class StatePredatorPatrol : StatePredatorNotStunned
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        base.Init(gameObject, states);

        Transition patrolToPursuit = new TransitionPredatorPatrolToPursuit();
        Transitions.Add("Patrol->Pursuit", patrolToPursuit);
        patrolToPursuit.Init(gameObject, states);

        Action = new StateActionPredatorPatrol().Init(gameObject, Transitions);
        EntryAction = new TransitionActionPredatorPatrolEntry().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}