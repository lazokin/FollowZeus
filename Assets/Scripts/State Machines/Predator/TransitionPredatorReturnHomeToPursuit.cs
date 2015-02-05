using UnityEngine;
using System.Collections.Generic;

public class TransitionPredatorReturnHomeToPursuit : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["Pursuit"];
        Action = new TransitionActionPredatorReturnHomeToPursuit().Init(gameObject);
        return this;
    }

    #endregion


}
