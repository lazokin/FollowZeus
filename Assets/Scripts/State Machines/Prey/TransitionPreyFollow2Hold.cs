using UnityEngine;
using System.Collections.Generic;

public class TransitionPreyFollow2Hold : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["hold"];
        Action = new TransitionActionPreyFollow2Hold().Init(gameObject);
        return this;
    }

    #endregion


}
