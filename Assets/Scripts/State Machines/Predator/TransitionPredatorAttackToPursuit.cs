using UnityEngine;
using System.Collections.Generic;

public class TransitionPredatorAttackToPursuit : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["Pursuit"];
        Action = new TransitionActionPredatorAttackToPursuit().Init(gameObject);
        return this;
    }

    #endregion


}
