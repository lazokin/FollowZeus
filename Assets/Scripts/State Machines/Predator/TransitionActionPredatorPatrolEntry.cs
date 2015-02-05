using UnityEngine;
using System.Collections.Generic;

public class TransitionActionPredatorPatrolEntry : TransitionAction
{
    private FollowCircularPath followCircularPath;

    #region implemented abstract members of Action

    public override TransitionAction Init(GameObject gameObject)
    {
        GameObject = gameObject;

        followCircularPath = gameObject.GetComponent<FollowCircularPath>();

        return this;
    }

    public override void Execute()
    {
        followCircularPath.SetPath(gameObject.GetComponent<PredatorController>().PatrolPath);
    }

    #endregion


}
