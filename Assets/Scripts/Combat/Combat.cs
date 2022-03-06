using UnityEngine;
using SD.Utility;
using SD.Inputs;
using SD.Movement;
using SD.Core.Action;

namespace SD.Combat
{
    public class Combat : MonoBehaviour, IAttackable,IAction
    {
        Target target;

        [SerializeField] float attackRange = 2f;

        private void Awake() {
            GetComponent<MouseInput>().OnPrimary += FindTarget;
        }

        private void Update()
        {
            if (target == null) return;
            if (GetIsInRange())
            {
                Attack(target);
            }else
            {
                MoveTo(target.transform.position);
            }
        }

        private void MoveTo(Vector3 position)
        {
            GetComponent<IMovePosition>().SetMovePosition(position);
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < attackRange;
        }

        public void Attack(Target target)
        {
            GetComponent<ActionScheduler>()?.ChangeAction(this);
            GetComponentInChildren<Animator>().SetTrigger("attack");

        }

        private void FindTarget()
        {
            RaycastHit[] hits = Functional.GetRaycastAll();
            foreach(RaycastHit hit in hits){
                Target target;

                if(hit.collider.TryGetComponent<Target>(out target))
                {
                    this.target = target;
                }
            }
        }

        public void Cancel()
        {
            this.target = null;
        }
    }
}
