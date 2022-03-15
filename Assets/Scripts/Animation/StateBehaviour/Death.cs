using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SD.Animation.StateBehaviour
{
    public class Death : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        //    Destroy(animator.gameObject);
        }
    }

}