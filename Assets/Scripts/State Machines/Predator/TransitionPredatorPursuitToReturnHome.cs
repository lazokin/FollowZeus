using UnityEngine;
using System.Collections.Generic;

public class TransitionPredatorPursuitToReturnHome : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["ReturnHome"];
        Action = new TransitionActionPredatorPursuitToReturnHome().Init(gameObject);
        return this;
    }

    #endregion


}
