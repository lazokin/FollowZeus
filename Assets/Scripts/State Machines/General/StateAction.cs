using UnityEngine;
using System.Collections.Generic;

public abstract class StateAction : Action
{
    protected GameObject gameObject;
    protected IDictionary<string, Transition> transitions;

    public GameObject GameObject
    {
        get
        {
            return gameObject;
        }
        set
        {
            gameObject = value;
        }
    }

    public IDictionary<string, Transition> Transitions
    {
        get
        {
            return transitions;
        }
        set
        {
            transitions = value;
        }
    }

    public virtual StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        GameObject = gameObject;
        Transitions = transitions;
        return this;
    }
}
