using UnityEngine;
using System.Collections.Generic;

public class StatePredatorAttack : StatePredatorNotStunned
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        base.Init(gameObject, states);

        Transition attackToPursuit = new TransitionPredatorAttackToPursuit();
        Transitions.Add("Attack->Pursuit", attackToPursuit);
        attackToPursuit.Init(gameObject, states);

        Action = new StateActionPredatorAttack().Init(gameObject, Transitions);
        EntryAction = new TransitionActionNull().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}