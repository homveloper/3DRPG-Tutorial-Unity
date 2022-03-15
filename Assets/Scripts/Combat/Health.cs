using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SD.Combat
{
    public class Health : MonoBehaviour, IDamage
    {
        [SerializeField] private float health;
        private bool isDead;

        public float HP
        {
            get => health;
            set
            {
                health = value;

                if (health <= 0)
                {
                    OnDie();
                }
            }
        }

        private void OnDie()
        {
            GetComponentInChildren<Animator>()?.SetTrigger("die");
            isDead = true;
        }

        public void TakeDamage(float damage)
        {
            HP -= damage;
        }

        public bool IsDead()
        {
            return isDead;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }

}