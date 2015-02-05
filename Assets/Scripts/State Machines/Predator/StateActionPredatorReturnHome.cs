using UnityEngine;
using System.Collections.Generic;

public class StateActionPredatorReturnHome : StateAction
{
    GameObject[] preyArray;
    GameObject target;
    private MovementController movementController;
    private PredatorController predatorController;
    private FollowLinearPath followLinearPath;
    private float startPursiutDistance;
    private LevelData levelData;

    PlayerController playerController;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        movementController = gameObject.GetComponent<MovementController>();
        predatorController = gameObject.GetComponent<PredatorController>();
        followLinearPath = gameObject.GetComponent<FollowLinearPath>();
        startPursiutDistance = predatorController.StartPursuitDistance;
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
            if (distanceToPrey < startPursiutDistance)
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
                                transitions ["ReturnHome->Pursuit"].IsTriggered = true;
                                break;
                            }
                        }
                        // Player has not lost over half the followers
                        else
                        {
                            transitions ["ReturnHome->Pursuit"].IsTriggered = true;
                            break;
                        }
                        
                    }
                    // Player does not have strike ammo
                    else
                    {
                        transitions ["ReturnHome->Pursuit"].IsTriggered = true;
                        break;
                    }
                }
                // Player does not have followers
                else
                {
                    transitions ["ReturnHome->Pursuit"].IsTriggered = true;
                    break;
                }
            }
        }

        movementController.Move(
            followLinearPath.LinearAcceleration(),
            followLinearPath.AngularAcceleration()
        );

        if (gameObject.rigidbody.velocity.magnitude < 0.5)
        {
            if (gameObject.GetComponent<PredatorController>().StartInPatrol)
            {
                transitions ["ReturnHome->Patrol"].IsTriggered = true;
            } else
            {
                transitions ["ReturnHome->Hold"].IsTriggered = true;
            }

        }

    }

    #endregion

}
