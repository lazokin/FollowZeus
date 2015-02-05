using UnityEngine;
using System.Collections.Generic;

public class TransitionActionPreyDontEvadeToEvade : TransitionAction
{
    PlayerController playerController;
    
    #region implemented abstract members of Action
    
    public override TransitionAction Init(GameObject gameObject)
    {
        GameObject = gameObject;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        return this;
    }
    
    public override void Execute()
    {
//        gameObject.renderer.material.color = Color.red;
        StateMachinePrey sm = gameObject.GetComponent<StateMachinePrey>();
        if (sm.CurrentState.GetType() == typeof(StatePreyFollow))
        {
            playerController.NumberOfFollowers--;
        }
    }
    
    #endregion 
    
}