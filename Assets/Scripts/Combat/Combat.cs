using UnityEngine;
using SD.Utility;

namespace SD.Combat
{
    public class Combat : MonoBehaviour, IAttackable
    {
        public void Attack()
        {
            
        }

        private void FindTarget()
        {
            RaycastHit[] hits = Functional.GetRaycastAll();
            foreach(RaycastHit hit in hits){
            }
        }
    }
}
