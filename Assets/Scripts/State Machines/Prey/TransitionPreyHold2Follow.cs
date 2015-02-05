using UnityEngine;
using System.Collections.Generic;

public class TransitionPreyHold2Follow : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["follow"];
        Action = new TransitionActionNull().Init(gameObject);
        return this;
    }

    #endregion


}
