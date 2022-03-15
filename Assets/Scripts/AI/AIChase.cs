using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SD.Movement;
using SD.Combat;

namespace SD.AI
{
    public class AIChase : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float stopDistance = 1f;
        [SerializeField] bool drawDebug = false;

        // Update is called once per frame
        void Update()
        {
            Transform target = GameObject.FindWithTag("Player").transform;
            float distance = DistanceToTarget(target);

            if (distance < stopDistance)
            {
                Stop();
            }
            else if (distance <= chaseDistance)
            {
                ChaseTarget(target);
            }
        }

        float DistanceToTarget(Transform target)
        {
            if (target != null)
                return Vector3.Distance(target.position, transform.position);

            return Mathf.Infinity;
        }

        void ChaseTarget(Transform target)
        {
            GetComponent<IMovePosition>().SetMovePosition(target.transform.position);
            GetComponent<IAttackable>().SetTarget(target.GetComponent<IDamage>());
        }

        void Stop()
        {
            GetComponent<IMovePosition>().Stop();
        }
    }

}