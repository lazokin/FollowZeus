using UnityEngine;
using System.Collections.Generic;

public class StatePredatorNotStunned : State
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        Transition notStunnedToStunned = new TransitionPredatorNotStunnedToStunned();
        Transitions.Add("NotStunned->Stunned", notStunnedToStunned);
        notStunnedToStunned.Init(gameObject, states);

        return this;
    }

    #endregion
}