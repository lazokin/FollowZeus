using UnityEngine;
using System.Collections.Generic;

public class StateMachinePrey : StateMachine
{
    #region implemented abstract members of StateMachine

    public override void Init()
    {
        State start = new StatePreyStart();
        State hold = new StatePreyHold();
        State follow = new StatePreyFollow();
        State evade = new StatePreyEvade();
        State safezone = new StatePreySafeZone();

        states.Add("start", start);
        states.Add("hold", hold);
        states.Add("follow", follow);
        states.Add("evade", evade);
        states.Add("safezone", safezone);

        start.Init(gameObject, states);
        hold.Init(gameObject, states);
        follow.Init(gameObject, states);
        evade.Init(gameObject, states);
        safezone.Init(gameObject, states);

        initialState = start;
        currentState = initialState;

        start.Transitions ["Start->Hold"].IsTriggered = true;
    }

    #endregion
}
