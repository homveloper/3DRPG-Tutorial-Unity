using UnityEngine;

namespace SD.Core.Action
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        public void ChangeAction(IAction action)
        {
            if (currentAction == action) return;
            Debug.Log(currentAction);
            currentAction?.Cancel();
            currentAction = action;
        }
    }
}