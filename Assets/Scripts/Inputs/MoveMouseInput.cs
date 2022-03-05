using UnityEngine;
using SD.Movement;
using SD.Utility;

namespace SD.Inputs
{
    public class MoveMouseInput : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 worldPosition = Functional.GetMouseWorldPosition3D(true);
                GetComponent<IMovePosition>()?.SetMovePosition(worldPosition);
            }
        }
    }
}