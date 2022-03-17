using UnityEngine;

namespace SD.Core.Action
{
    public class ActionScheduler : MonoBehaviour
    {
        [SerializeField] private IAction currentAction;

        public void ChangeAction(IAction action)
        {
            if (currentAction == action) return;
            currentAction?.Cancel();
            currentAction = action;
        }

        public void CancelCurrentAction()
        {
            ChangeAction(null);
        }
    }
}