using UnityEngine;
using System.Collections.Generic;

public class StatePreySafeZone : State
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        Transition safeZoneToFollow = new TransitionPreySafeZoneToFollow();
        Transitions.Add("SafeZone->Follow", safeZoneToFollow);
        safeZoneToFollow.Init(gameObject, states);

        Action = new StateActionPreySafeZone().Init(gameObject, Transitions);
        EntryAction = new TransitionActionNull().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}