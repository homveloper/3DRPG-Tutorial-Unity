using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SD.Movement;
using SD.Combat;
using SD.Core.Action;

namespace SD.Core
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
            GetComponent<ActionScheduler>()?.CancelCurrentAction();
            GetComponent<IMovePosition>()?.SetControl(false);
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