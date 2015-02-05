using UnityEngine;
using System.Collections.Generic;

public class StateActionPreyDontEvade : StateAction
{
    protected GameObject player;
    protected GameObject[] predatorArray;
    private float startEvadeDistance;
    private LevelData levelData;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        player = GameObject.Find("Player");
        startEvadeDistance = gameObject.GetComponent<PreyController>().StartEvadeDistance;
        levelData = GameObject.Find("Level Manager").GetComponent<LevelData>();

        return this;
    }

    public override void Execute()
    {
        predatorArray = levelData.PredatorArray;
        foreach (GameObject predator in predatorArray)
        {
            float distanceToPredator = (gameObject.transform.position - predator.transform.position).magnitude;
            if (distanceToPredator < startEvadeDistance)
            {
                transitions ["DontEvade->Evade"].IsTriggered = true;
                break;
            }
        }
    }

    #endregion


}
