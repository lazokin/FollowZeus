using UnityEngine;
using System.Collections.Generic;

public class TransitionPreyFollowToSafeZone : Transition
{
    #region implemented abstract members of Transition

    public override Transition Init(GameObject gameObject, IDictionary<string, State> states)
    {
        IsTriggered = false;
        TargetState = states ["safezone"];
        Action = new TransitionActionPreyFollowToSafeZone().Init(gameObject);
        return this;
    }

    #endregion


}
