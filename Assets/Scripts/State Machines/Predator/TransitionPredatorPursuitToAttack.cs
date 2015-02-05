using UnityEngine;
using System.Collections.Generic;

public class TransitionPredatorPursuitToAttack : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["Attack"];
        Action = new TransitionActionPredatorPursuitToAttack().Init(gameObject);
        return this;
    }

    #endregion


}
