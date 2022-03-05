using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SD.Movement;

public class Locomotion : StateMachineBehaviour
{


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.SetFloat("moveSpeed", GetScaledMoveSpeed(animator));
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // Return scaled move speed by 0 ~ 1
    private float GetScaledMoveSpeed(Animator animator){
        IMovePosition movePosition = animator.GetComponentInParent<IMovePosition>();
        if(movePosition != null)
            return movePosition.GetVelocity().z / movePosition.GetMaxMoveSpeed();
        
        return 0;
    }
}
