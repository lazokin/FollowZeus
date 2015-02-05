using UnityEngine;
using System.Collections.Generic;

public class TransitionActionPreyFollowToSafeZone : TransitionAction
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
        playerController.NumberOfFollowers--;
    }
    
    #endregion  
    
}