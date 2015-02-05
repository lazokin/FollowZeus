using UnityEngine;
using System.Collections.Generic;

public class TransitionPredatorHoldToPursuit : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["Pursuit"];
        Action = new TransitionActionPredatorHoldToPursuit().Init(gameObject);
        return this;
    }

    #endregion


}
