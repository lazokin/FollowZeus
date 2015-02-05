using UnityEngine;
using System.Collections.Generic;

public class StatePreyEvade : State
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        Transition evadeToHold = new TransitionPreyEvadeToHold();
        Transitions.Add("Evade->Hold", evadeToHold);
        evadeToHold.Init(gameObject, states);

        Action = new StateActionPreyEvade().Init(gameObject, Transitions);
        EntryAction = new TransitionActionNull().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}