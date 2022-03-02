using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomVeloper.Utiltiy
{
    public class Functional
    {
        public static Vector3 GetMouseWorldPosition2D() {
            Vector3 vec = GetMouseWorldPosition2DWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }
        public static Vector3 GetMouseWorldPosition2DWithZ() {
            return GetMouseWorldPosition2DWithZ(Input.mousePosition, Camera.main);
        }
        public static Vector3 GetMouseWorldPosition2DWithZ(Camera worldCamera) {
            return GetMouseWorldPosition2DWithZ(Input.mousePosition, worldCamera);
        }
        public static Vector3 GetMouseWorldPosition2DWithZ(Vector3 screenPosition, Camera worldCamera) {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        public static Vector3 GetMouseWorldPosition3D(bool debug=false){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(debug)
                Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.green);
            
            if(Physics.Raycast(ray, out hit)){
                return hit.point;
            }

            return Vector3.zero;
        }
    }
}

