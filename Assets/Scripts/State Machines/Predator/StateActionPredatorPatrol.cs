using UnityEngine;
using System.Collections.Generic;

public class StateActionPredatorPatrol : StateAction
{
    GameObject[] preyArray;
    private float startPursuitDistance;
    private MovementController movementController;
    private FollowCircularPath followCircularPath;
    private LevelData levelData;

    PlayerController playerController;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        startPursuitDistance = gameObject.GetComponent<PredatorController>().StartPursuitDistance;
        movementController = gameObject.GetComponent<MovementController>();
        followCircularPath = gameObject.GetComponent<FollowCircularPath>();
        levelData = GameObject.Find("Level Manager").GetComponent<LevelData>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        return this;
    }

    public override void Execute()
    {
        preyArray = levelData.PreyArray;
        foreach (GameObject prey in preyArray)
        {
            float distanceToPrey = (gameObject.transform.position - prey.transform.position).magnitude;

            // Predator attack decision tree
            if (distanceToPrey < startPursuitDistance)
            {
                // Player has followers
                if (playerController.NumberOfFollowers > 0)
                {
                    // Player has strike ammo
                    if (LevelData.ammoStrike > 0)
                    {
                        // Player has lost over half the followers
                        if (LevelData.lostNumberOfPrey > LevelData.startNumberOfPrey / 2)
                        {
                            // Attack with low probability
                            if (Random.Range(0, 100) < 1)
                            {
                                transitions ["Patrol->Pursuit"].IsTriggered = true;
                            }
                        }
                        // Player has not lost over half the followers
                        else
                        {
                            transitions ["Patrol->Pursuit"].IsTriggered = true;
                        }
                        
                    }
                    // Player does not have strike ammo
                    else
                    {
                        transitions ["Patrol->Pursuit"].IsTriggered = true;
                    }
                }
                // Player does not have followers
                else
                {
                    transitions ["Patrol->Pursuit"].IsTriggered = true;
                }
            }
        }

        movementController.Move(
            followCircularPath.LinearAcceleration(),
            followCircularPath.AngularAcceleration()
        );

    }

    #endregion

}
