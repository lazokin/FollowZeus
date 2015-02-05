using UnityEngine;
using System.Collections.Generic;

public class TransitionPredatorStartToHold : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["Hold"];
        Action = new TransitionActionPredatorStartToHold().Init(gameObject);
        return this;
    }

    #endregion


}
