using UnityEngine;
using System.Collections.Generic;

public class TransitionPredatorStartToPatrol : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["Patrol"];
        Action = new TransitionActionPredatorStartToPatrol().Init(gameObject);
        return this;
    }

    #endregion


}
