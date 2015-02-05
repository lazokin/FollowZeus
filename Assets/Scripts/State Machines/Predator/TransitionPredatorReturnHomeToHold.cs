using UnityEngine;
using System.Collections.Generic;

public class TransitionPredatorReturnHomeToHold : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["Hold"];
        Action = new TransitionActionPredatorReturnHomeToHold().Init(gameObject);
        return this;
    }

    #endregion


}
