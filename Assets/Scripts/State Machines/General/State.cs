using UnityEngine;
using System.Collections.Generic;

public abstract class State
{
    protected StateAction action;
    protected TransitionAction entryAction;
    protected TransitionAction exitAction;
    protected IDictionary<string, Transition> transitions = new Dictionary<string, Transition>();

    public StateAction Action
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

    public TransitionAction EntryAction
    {
        get
        {
            return entryAction;
        }
        set
        {
            entryAction = value;
        }
    }

    public TransitionAction ExitAction
    {
        get
        {
            return exitAction;
        }
        set
        {
            exitAction = value;
        }
    }

    public IDictionary<string, Transition> Transitions
    {
        get
        {
            return transitions;
        }
    }

    public abstract State Init(GameObject gameObject, IDictionary<string, State> states);
}
