using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyController : Controller
{
    public float lookRadius = 10f;
    private Transform target;
    public NavMeshAgent ai { get; private set; }
    public event Action<Dictionary<string, AttackComponent>> OnMeleeAttack = delegate { };
    private float lastAttackTime;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        ai = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && ai.enabled)
        {
            ai.SetDestination(target.position);

            if (distance <= ai.stoppingDistance)
            {
                FaceTarget();
                if (lastAttackTime + 2 <= Time.time)
                {
                    lastAttackTime = Time.time;
                    OnMeleeAttack(Attacks);
                }
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
