using UnityEngine;
using System.Collections.Generic;

public class TransitionPredatorNotStunnedToStunned : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["Stunned"];
        Action = new TransitionActionPredatorNotStunnedToStunned().Init(gameObject);
        return this;
    }

    #endregion


}
