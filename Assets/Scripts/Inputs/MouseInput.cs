using UnityEngine;
using SD.Movement;
using SD.Utility;
using System;

namespace SD.Inputs
{
    public class MouseInput : MonoBehaviour
    {
        public event Action OnPrimary = delegate {};
        public event Action OnSecondary = delegate {};

        private void Update()
        {
            if(Input.GetButton("Primary")){
                OnPrimary();
            }

            if (Input.GetButton("Secondary"))
            {
                Vector3 worldPosition = Functional.GetMouseWorldPosition3D(true);
                if(worldPosition != Vector3.zero){
                    GetComponent<IMovePosition>()?.SetMovePosition(worldPosition);
                }
                OnSecondary();
            }
        }
    }
}