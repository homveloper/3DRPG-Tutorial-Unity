using UnityEngine;
using UnityEngine.AI;

public class MovePositionNavMesh : MonoBehaviour, IMovePosition
{
    private NavMeshAgent agent;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetMovePosition(Vector3 movePosition)
    {
        agent.SetDestination(movePosition);
        Stop(false);
    }

    public void Stop(bool condition)
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
}