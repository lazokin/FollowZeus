using UnityEngine;
using System.Collections.Generic;

public class StateActionPredatorPursuit : StateAction
{
    GameObject[] preyArray;
    GameObject target;
    private MovementController movementController;
    private PredatorController predatorController;
    private FollowLinearPath followLinearPath;
    private PathPlanner pathPlanner;
    private float startAttackDistance;
    private float breakPursuitDistance;
    private float pathPlanningUpdateTime;
    private float pathPlanningTimer = 0;
    private LevelData levelData;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        movementController = gameObject.GetComponent<MovementController>();
        predatorController = gameObject.GetComponent<PredatorController>();
        followLinearPath = gameObject.GetComponent<FollowLinearPath>();
        pathPlanner = gameObject.GetComponent<PathPlanner>();
        startAttackDistance = predatorController.StartAttackDistance;
        breakPursuitDistance = predatorController.BreakPursuitDistance;
        pathPlanningUpdateTime = predatorController.PathPlanningUpdateTime;
        levelData = GameObject.Find("Level Manager").GetComponent<LevelData>();

        return this;
    }

    public override void Execute()
    {
        preyArray = levelData.PreyArray;
        target = null;
        foreach (GameObject prey in preyArray)
        {
            float distanceToPrey = (gameObject.transform.position - prey.transform.position).magnitude;
            if (distanceToPrey < startAttackDistance)
            {
                transitions ["Pursuit->Attack"].IsTriggered = true;
                break;
            }
            if (distanceToPrey < breakPursuitDistance)
            {
                target = prey;
            }
        }

        if (target == null)
        {
            transitions ["Pursuit->ReturnHome"].IsTriggered = true;
        } else
        {
            if (pathPlanningTimer > pathPlanningUpdateTime)
            {
                followLinearPath.SetPath(pathPlanner.FindPath(gameObject.transform.position, target.transform.position));
                pathPlanningTimer = 0;
            }
            pathPlanningTimer += Time.deltaTime;

            movementController.Move(
                followLinearPath.LinearAcceleration(),
                followLinearPath.AngularAcceleration()
            );
        }



    }

    #endregion

}
