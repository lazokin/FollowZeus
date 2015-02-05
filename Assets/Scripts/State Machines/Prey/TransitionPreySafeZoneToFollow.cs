using UnityEngine;
using System.Collections.Generic;

public class TransitionPreySafeZoneToFollow : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["follow"];
        Action = new TransitionActionPreySafeZoneToFollow().Init(gameObject);
        return this;
    }

    #endregion


}
