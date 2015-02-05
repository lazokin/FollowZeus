using UnityEngine;
using System.Collections.Generic;

public abstract class Transition
{
    protected bool isTriggered;
    protected State targetState;
    protected TransitionAction action;

    public bool IsTriggered
    {
        get
        {
            return isTriggered;
        }
        set
        {
            isTriggered = value;
        }
    }

    public State TargetState
    {
        get
        {
            return targetState;
        }
        set
        {
            targetState = value;
        }
    }

    public TransitionAction Action
    {
        get
        {
            return action;
        }
        set
        {
            action = value;
        }
    }

    public abstract Transition Init(GameObject gameObject, IDictionary<string, State> states);
}