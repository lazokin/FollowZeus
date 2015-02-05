using UnityEngine;
using System.Collections.Generic;

public class StatePreyFollow : StatePreyDontEvade
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        base.Init(gameObject, states);

        Transition followToHold = new TransitionPreyFollowToHold();
        Transitions.Add("Follow->Hold", followToHold);
        followToHold.Init(gameObject, states);

        Transition followToSafeZone = new TransitionPreyFollowToSafeZone();
        Transitions.Add("Follow->SafeZone", followToSafeZone);
        followToSafeZone.Init(gameObject, states);

        Action = new StateActionPreyFollow().Init(gameObject, Transitions);
        EntryAction = new TransitionActionNull().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}