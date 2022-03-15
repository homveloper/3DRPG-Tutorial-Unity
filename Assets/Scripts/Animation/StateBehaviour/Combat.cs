using UnityEngine;

namespace SD.Animation.StateBehaviour
{
    public class Combat : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
            
        // }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }
    }
}