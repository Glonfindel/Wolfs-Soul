using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    private Animator animator;
    private EnemyController enemyController;
    private Health health;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        enemyController = GetComponent<EnemyController>();
        health = GetComponent<Health>();
        enemyController.OnMeleeAttack += HandleMeleeAttack;
        health.OnDie += HandleDeath;
        health.OnDamageTaken += HandleGetHit;
    }

    private void OnDestroy()
    {
        enemyController.OnMeleeAttack -= HandleMeleeAttack;
        health.OnDie -= HandleDeath;
        health.OnDamageTaken -= HandleGetHit;
    }

    private void Update()
    {
        animator.SetFloat("Vertical", enemyController.ai.velocity.magnitude);
        animator.SetBool("CancelIdleAction", Input.anyKey);
        animator.SetBool("Grounded", true);
    }

    private void HandleMeleeAttack()
    {
        animator.Play("MeleeAttack");
    }

    private void HandleGetHit()
    {
        animator.Play("GetHit");
    }

    private void HandleDeath()
    {
        animator.Play("Death");
    }

}
