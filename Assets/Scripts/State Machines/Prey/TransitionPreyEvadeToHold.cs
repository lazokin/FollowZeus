using UnityEngine;
using System.Collections.Generic;

public class TransitionPreyEvadeToHold : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["hold"];
        Action = new TransitionActionPreyEvadeToHold().Init(gameObject);
        return this;
    }

    #endregion


}
