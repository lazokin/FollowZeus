using UnityEngine;
using System.Collections.Generic;

public class TransitionActionPredatorHoldToPursuit : TransitionAction
{
    #region implemented abstract members of Action

    public override TransitionAction Init(GameObject gameObject)
    {
        GameObject = gameObject;
        return this;
    }

    public override void Execute()
    {

    }

    #endregion


}
