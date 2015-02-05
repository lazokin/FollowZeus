using UnityEngine;
using System.Collections.Generic;

public abstract class TransitionAction : Action
{
    protected GameObject gameObject;

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

    public abstract TransitionAction Init(GameObject gameObject);
}
