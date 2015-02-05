using UnityEngine;
using System.Collections.Generic;

public class StatePredatorStart : State
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        Transition startToHold = new TransitionPredatorStartToHold();
        Transitions.Add("Start->Hold", startToHold);
        startToHold.Init(gameObject, states);

        Transition startToPatrol = new TransitionPredatorStartToPatrol();
        Transitions.Add("Start->Patrol", startToPatrol);
        startToPatrol.Init(gameObject, states);

        Action = new StateActionNull().Init(gameObject, Transitions);
        EntryAction = new TransitionActionNull().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}