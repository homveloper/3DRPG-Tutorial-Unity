using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update() {
        if(target == null) return;
        GetComponent<IMovePosition>().SetMovePosition(target.position);
    }
}