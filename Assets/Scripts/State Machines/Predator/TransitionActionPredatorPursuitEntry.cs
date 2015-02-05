using UnityEngine;
using System.Collections.Generic;

public class TransitionActionPredatorPursuitEntry : TransitionAction
{
    private PredatorController predatorController;
    private FollowLinearPath followLinearPath;
    private PathPlanner pathPlanner;

    GameObject[] preyArray;

    private float startPursuitDistance;
    private float breakPursuitDistance;

    #region implemented abstract members of Action

    public override TransitionAction Init(GameObject gameObject)
    {
        GameObject = gameObject;

        predatorController = gameObject.GetComponent<PredatorController>();
        followLinearPath = gameObject.GetComponent<FollowLinearPath>();
        pathPlanner = gameObject.GetComponent<PathPlanner>();

        startPursuitDistance = predatorController.StartPursuitDistance;
        breakPursuitDistance = predatorController.BreakPursuitDistance;

        return this;
    }

    public override void Execute()
    {
        preyArray = GameObject.FindGameObjectsWithTag("Prey");
        foreach (GameObject prey in preyArray)
        {
            float distanceToPrey = (gameObject.transform.position - prey.transform.position).magnitude;
            if (distanceToPrey < startPursuitDistance)
            {
                followLinearPath.SetPath(pathPlanner.FindPath(gameObject.transform.position, prey.transform.position));
                break;
            }
            if (distanceToPrey < breakPursuitDistance)
            {
                followLinearPath.SetPath(pathPlanner.FindPath(gameObject.transform.position, prey.transform.position));
                break;
            }
        }
    }

    #endregion


}
