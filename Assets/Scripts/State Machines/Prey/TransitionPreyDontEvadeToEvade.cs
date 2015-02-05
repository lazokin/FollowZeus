using UnityEngine;
using System.Collections.Generic;

public class TransitionPreyDontEvadeToEvade : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["evade"];
        Action = new TransitionActionPreyDontEvadeToEvade().Init(gameObject);
        return this;
    }

    #endregion


}
