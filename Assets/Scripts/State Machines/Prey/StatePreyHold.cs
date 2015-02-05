using UnityEngine;
using System.Collections.Generic;

public class StatePreyHold : StatePreyDontEvade
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        base.Init(gameObject, states);

        Transition holdToFollow = new TransitionPreyHoldToFollow();
        Transitions.Add("Hold->Follow", holdToFollow);
        holdToFollow.Init(gameObject, states);

        Action = new StateActionPreyHold().Init(gameObject, Transitions);
        EntryAction = new TransitionActionNull().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}