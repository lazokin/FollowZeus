using UnityEngine;
using System.Collections.Generic;

public class TransitionActionPreyFollowToHold : TransitionAction
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
        gameObject.rigidbody.velocity = Vector3.zero;
        playerController.NumberOfFollowers--;
    }
    
    #endregion  
    
}