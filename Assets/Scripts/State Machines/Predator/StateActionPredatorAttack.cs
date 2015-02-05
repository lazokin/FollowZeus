using UnityEngine;
using System.Collections.Generic;

public class StateActionPredatorAttack : StateAction
{
    GameObject[] preyArray;
    GameObject target;
    private MovementController movementController;
    private Seek seek;
    private float breakAttackDistance;
    private LevelData levelData;

    #region implemented abstract members of Action

    public override StateAction Init(GameObject gameObject, IDictionary<string, Transition> transitions)
    {
        base.Init(gameObject, transitions);

        movementController = gameObject.GetComponent<MovementController>();
        seek = gameObject.GetComponent<Seek>();
        breakAttackDistance = gameObject.GetComponent<PredatorController>().BreakAttackDistance;
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
            if (distanceToPrey < breakAttackDistance)
            {
                target = prey;
            }
        }

        if (target == null)
        {
            transitions ["Attack->Pursuit"].IsTriggered = true;
        } else
        {
            movementController.Move(
                seek.LinearAcceleration(target.transform.position),
                seek.AngularAcceleration(target.transform.position)
            );
        }



    }

    #endregion

}
