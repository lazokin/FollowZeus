using UnityEngine;
using System.Collections.Generic;

public abstract class StateMachine : MonoBehaviour
{
    protected IDictionary<string, State> states = new Dictionary<string, State>();

    protected State initialState;

    protected State previousState;
    public State PreviousState
    {
        get
        {
            return previousState;
        }
    }

    protected State currentState;
    public State CurrentState
    {
        get
        {
            return currentState;
        }
    }

    protected State targetState;

    protected Transition triggeredTransition;

    void Start()
    {
        Init();
    }
	
    void Update()
    {
        triggeredTransition = null;

        // Find triggered transition
        foreach (Transition transition in currentState.Transitions.Values)
        {
            if (transition.IsTriggered)
            {
                triggeredTransition = transition;
                break;
            }
        }

        // No triggered transition
        if (triggeredTransition == null)
        {
            // Execute action for currrent state
            currentState.Action.Execute();
        }
        // Triggered transition.
        else
        {
            targetState = triggeredTransition.TargetState;

            // Execute exit action for current state
            currentState.ExitAction.Execute();

            // Execute transition action for triggered transition
            triggeredTransition.Action.Execute();

            // Execute entry action for target state
            targetState.EntryAction.Execute();

            // Change states
            previousState = currentState;
            currentState = targetState;

            // Reset transition triggers
            foreach (Transition transition in currentState.Transitions.Values)
            {
                transition.IsTriggered = false;
            }
        }

    }

    public abstract void Init();
}
