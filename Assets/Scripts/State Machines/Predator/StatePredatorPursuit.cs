using UnityEngine;
using System.Collections.Generic;

public class StatePredatorPursuit : StatePredatorNotStunned
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        base.Init(gameObject, states);

        Transition pursuitToAttack = new TransitionPredatorPursuitToAttack();
        Transitions.Add("Pursuit->Attack", pursuitToAttack);
        pursuitToAttack.Init(gameObject, states);

        Transition pursuitToReturnHome = new TransitionPredatorPursuitToReturnHome();
        Transitions.Add("Pursuit->ReturnHome", pursuitToReturnHome);
        pursuitToReturnHome.Init(gameObject, states);

        Action = new StateActionPredatorPursuit().Init(gameObject, Transitions);
        EntryAction = new TransitionActionPredatorPursuitEntry().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}