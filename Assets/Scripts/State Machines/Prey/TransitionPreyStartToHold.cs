using UnityEngine;
using System.Collections.Generic;

public class TransitionPreyStartToHold : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["hold"];
        Action = new TransitionActionPreyStartToHold().Init(gameObject);
        return this;
    }

    #endregion


}
