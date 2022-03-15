using UnityEngine;
using SD.Utility;
using SD.Inputs;
using SD.Movement;
using SD.Core.Action;

namespace SD.Combat
{
    public class Combat : MonoBehaviour, IAttackable,IAction
    {
        IDamage target;

        [SerializeField] float attackRange = 2f;
        [SerializeField] float attackPerSecond = 1f;
        [SerializeField] float attackDamage = 1f;

        private float lastAttackTime = 0f;

        private void Awake() {
            MouseInput mouseInput;
            if(TryGetComponent<MouseInput>(out mouseInput))
            {
                mouseInput.OnPrimary += FindTarget;
            }
        }

        private void Update()
        {
            if (target == null) return;
            if (target.IsDead()) return;

            if (GetIsInRange())
            {
                if(IsCooltimeEnd())
                {
                    Attack(target);
                }
            }else
            {
                MoveTo(target.GetPosition());
            }
        }

        private bool IsCooltimeEnd()
        {
            return Time.time > lastAttackTime;
        }

        private void MoveTo(Vector3 position)
        {
            GetComponent<IMovePosition>().SetMovePosition(position);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.GetPosition()) < attackRange;
        }

        public void Attack(IDamage target)
        {
            transform.LookAt(this.target.GetTransform());
            GetComponent<ActionScheduler>()?.ChangeAction(this);
            GetComponent<Animator>()?.ResetTrigger("stopAttack");
            GetComponent<Animator>()?.SetTrigger("attack");
            lastAttackTime = Time.time + attackPerSecond;
        }

        public void SetTarget(IDamage target)
        {
            this.target = target;
        }

        private void FindTarget()
        {
            RaycastHit[] hits = Functional.GetRaycastAll();
            foreach(RaycastHit hit in hits){
                IDamage target;
                if(hit.collider.TryGetComponent<IDamage>(out target))
                {
                    if(!CanAttack(target)) continue;
                    SetTarget(target);
                    break;
                }
            }
        }

        public void Cancel()
        {
            GetComponentInChildren<Animator>().ResetTrigger("attack");
            GetComponentInChildren<Animator>().SetTrigger("stopAttack");
            this.target = null;
        }

        public bool CanAttack(IDamage target)
        {
            return target != null && !target.IsDead();
        }

        // Animation Event Receiver
        private void Hit()
        {
            target.TakeDamage(attackDamage); 
        }
    }
}
