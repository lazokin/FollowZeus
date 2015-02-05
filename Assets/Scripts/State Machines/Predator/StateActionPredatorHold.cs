using UnityEngine;
using System.Collections.Generic;

public class StateActionPredatorHold : StateAction
{
    GameObject[] preyArray;
    private float startPursuitDistance;
    private LevelData levelData;

    PlayerController playerController;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        startPursuitDistance = gameObject.GetComponent<PredatorController>().StartPursuitDistance;
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
                                transitions ["Hold->Pursuit"].IsTriggered = true;
                            }
                        }
                        // Player has not lost over half the followers
                        else
                        {
                            transitions ["Hold->Pursuit"].IsTriggered = true;
                        }

                    }
                    // Player does not have strike ammo
                    else
                    {
                        transitions ["Hold->Pursuit"].IsTriggered = true;
                    }
                }
                // Player does not have followers
                else
                {
                    transitions ["Hold->Pursuit"].IsTriggered = true;
                }
            }
        }

    }

    #endregion

}
