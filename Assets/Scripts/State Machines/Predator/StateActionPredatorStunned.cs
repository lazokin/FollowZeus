using UnityEngine;
using System.Collections.Generic;

public class StateActionPredatorStunned : StateAction
{
    private float stunnedTimeout;
    private float timer = 0;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        stunnedTimeout = gameObject.GetComponent<PredatorController>().StunnedTimeout;

        return this;
    }

    public override void Execute()
    {
        timer += Time.deltaTime;
        if (timer > stunnedTimeout)
        {
            transitions ["Stunned->ReturnHome"].IsTriggered = true;
            timer = 0;
        }
    }

    #endregion

}
