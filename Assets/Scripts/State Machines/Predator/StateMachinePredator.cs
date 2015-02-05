using UnityEngine;
using System.Collections;

public class StateMachinePredator : StateMachine
{
    private State start;
    private State hold;
    private State patrol;
    private State pursuit;
    private State attack;
    private State returnHome;
    private State stunned;

    #region implemented abstract members of StateMachine

    public override void Init()
    {
        start = new StatePredatorStart();
        hold = new StatePredatorHold();
        patrol = new StatePredatorPatrol();
        pursuit = new StatePredatorPursuit();
        attack = new StatePredatorAttack();
        returnHome = new StatePredatorReturnHome();
        stunned = new StatePredatorStunned();

        states.Add("Start", start);
        states.Add("Hold", hold);
        states.Add("Patrol", patrol);
        states.Add("Pursuit", pursuit);
        states.Add("Attack", attack);
        states.Add("ReturnHome", returnHome);
        states.Add("Stunned", stunned);

        start.Init(gameObject, states);
        hold.Init(gameObject, states);
        patrol.Init(gameObject, states);
        pursuit.Init(gameObject, states);
        attack.Init(gameObject, states);
        returnHome.Init(gameObject, states);
        stunned.Init(gameObject, states);

        initialState = start;
        currentState = initialState;

        if (gameObject.GetComponent<PredatorController>().StartInPatrol)
        {
            start.Transitions ["Start->Patrol"].IsTriggered = true;
        } else
        {
            start.Transitions ["Start->Hold"].IsTriggered = true;
        }

    }

    public void HitByStrike()
    {
        if (currentState != stunned)
        {
            currentState.Transitions ["NotStunned->Stunned"].IsTriggered = true;
        }
        
    }

    #endregion
}
