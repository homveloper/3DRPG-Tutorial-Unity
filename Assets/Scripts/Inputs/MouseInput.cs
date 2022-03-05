using UnityEngine;
using SD.Movement;
using SD.Utility;
using System;

namespace SD.Inputs
{
    public class MouseInput : MonoBehaviour
    {
        public event Action OnPrimary = delegate {};

        private void Update()
        {
            if(Input.GetButtonDown("Primary")){
                OnPrimary();
            }
        }
    }
}