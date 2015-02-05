using UnityEngine;
using System.Collections.Generic;

public class StatePredatorStunned : State
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        Transition stunnedToReturnHome = new TransitionPredatorStunnedToReturnHome();
        Transitions.Add("Stunned->ReturnHome", stunnedToReturnHome);
        stunnedToReturnHome.Init(gameObject, states);

        Action = new StateActionPredatorStunned().Init(gameObject, Transitions);
        EntryAction = new TransitionActionNull().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}