using UnityEngine;
using System.Collections.Generic;

public class StatePredatorHold : StatePredatorNotStunned
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        base.Init(gameObject, states);

        Transition holdToPursuit = new TransitionPredatorHoldToPursuit();
        Transitions.Add("Hold->Pursuit", holdToPursuit);
        holdToPursuit.Init(gameObject, states);

        Action = new StateActionPredatorHold().Init(gameObject, Transitions);
        EntryAction = new TransitionActionNull().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}