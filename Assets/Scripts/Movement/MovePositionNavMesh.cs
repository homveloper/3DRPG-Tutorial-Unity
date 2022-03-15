using SD.Core.Action;
using UnityEngine;
using UnityEngine.AI;

namespace SD.Movement
{
    public class MovePositionNavMesh : MonoBehaviour, IMovePosition, IAction
    {
        private NavMeshAgent agent;
        private bool canControl = true;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void SetMovePosition(Vector3 movePosition)
        {
            if(!canControl) return;

            GetComponent<ActionScheduler>()?.ChangeAction(this);
            agent.SetDestination(movePosition);
            Stop(false);
        }

        public void Stop(bool condition = true)
        {
            agent.isStopped = condition;
        }

        public Vector3 GetVelocity()
        {
            return transform.InverseTransformDirection(agent.velocity);
        }

        public float GetMaxMoveSpeed()
        {
            return agent.speed;
        }

        public void Cancel()
        {
            Stop();
        }

        public void SetControl(bool condition)
        {
            canControl = condition;
        }
    }
}