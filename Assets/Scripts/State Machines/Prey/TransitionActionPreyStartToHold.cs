using UnityEngine;
using System.Collections.Generic;

public class TransitionActionPreyStartToHold : TransitionAction
{
    #region implemented abstract members of Action

    public override TransitionAction Init(GameObject gameObject)
    {
        GameObject = gameObject;
        return this;
    }

    public override void Execute()
    {
//        gameObject.renderer.material.color = Color.black;
    }

    #endregion


}
