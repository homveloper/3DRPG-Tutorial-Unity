using UnityEngine;

namespace SD.Combat
{
    public interface IDamage
    {
        public void TakeDamage(float damage);
        public bool IsDead();
        public Vector3 GetPosition();

        public Transform GetTransform();

    }
}