using UnityEngine;
using System.Collections.Generic;

public class StatePredatorReturnHome : StatePredatorNotStunned
{
    #region implemented abstract members of State

    public override State Init(GameObject gameObject, IDictionary<string, State> states)
    {
        base.Init(gameObject, states);

        Transition returnHomeToHold = new TransitionPredatorReturnHomeToHold();
        Transitions.Add("ReturnHome->Hold", returnHomeToHold);
        returnHomeToHold.Init(gameObject, states);

        Transition returnHomeToPatrol = new TransitionPredatorReturnHomeToPatrol();
        Transitions.Add("ReturnHome->Patrol", returnHomeToPatrol);
        returnHomeToPatrol.Init(gameObject, states);

        Transition returnHomeToPursuit = new TransitionPredatorReturnHomeToPursuit();
        Transitions.Add("ReturnHome->Pursuit", returnHomeToPursuit);
        returnHomeToPursuit.Init(gameObject, states);

        Action = new StateActionPredatorReturnHome().Init(gameObject, Transitions);
        EntryAction = new TransitionActionPredatorReturnHomeEntry().Init(gameObject);
        ExitAction = new TransitionActionNull().Init(gameObject);

        return this;
    }

    #endregion
}