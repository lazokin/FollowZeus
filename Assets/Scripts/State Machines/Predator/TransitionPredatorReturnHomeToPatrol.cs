using UnityEngine;
using System.Collections.Generic;

public class TransitionPredatorReturnHomeToPatrol : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["Patrol"];
        Action = new TransitionActionPredatorReturnHomeToPatrol().Init(gameObject);
        return this;
    }

    #endregion


}
