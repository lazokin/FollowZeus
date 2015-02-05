using UnityEngine;
using System.Collections.Generic;

public class StateActionNull : StateAction
{
    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        GameObject = gameObject;
        Transitions = transitions;
        return this;
    }

    public override void Execute()
    {
        // Do Nothing
    }

    #endregion


}
