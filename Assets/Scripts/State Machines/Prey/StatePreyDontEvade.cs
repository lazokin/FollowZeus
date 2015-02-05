using UnityEngine;
using System.Collections.Generic;

public abstract class StatePreyDontEvade : State
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        Transition dontEvadeToEvade = new TransitionPreyDontEvadeToEvade();
        Transitions.Add("DontEvade->Evade", dontEvadeToEvade);
        dontEvadeToEvade.Init(gameObject, states);

        return this;
    }

    #endregion
}