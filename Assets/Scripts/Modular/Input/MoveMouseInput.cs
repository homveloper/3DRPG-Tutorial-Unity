using UnityEngine;
using HomVeloper.Utiltiy;

public class MoveMouseInput : MonoBehaviour {
    private void Update() {
        if(Input.GetMouseButton(0)){
            Vector3 worldPosition = Functional.GetMouseWorldPosition3D(true);
            GetComponent<IMovePosition>().SetMovePosition(worldPosition);
        }
    }
}