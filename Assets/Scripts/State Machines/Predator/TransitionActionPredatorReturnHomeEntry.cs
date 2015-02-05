using UnityEngine;
using System.Collections.Generic;

public class TransitionActionPredatorReturnHomeEntry : TransitionAction
{
    private FollowLinearPath followLinearPath;
    private PathPlanner pathPlanner;
    private Vector3 homePosition;

    #region implemented abstract members of Action

    public override TransitionAction Init(GameObject gameObject)
    {
        GameObject = gameObject;

        followLinearPath = gameObject.GetComponent<FollowLinearPath>();
        pathPlanner = gameObject.GetComponent<PathPlanner>();
        homePosition = gameObject.GetComponent<PredatorController>().HomePosition;

        return this;
    }

    public override void Execute()
    {
        followLinearPath.SetPath(pathPlanner.FindPath(gameObject.transform.position, homePosition));
    }

    #endregion


}
