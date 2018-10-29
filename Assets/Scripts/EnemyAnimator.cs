using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        enemyController.OnMeleeAttack += HandleAttack;
        health.OnDie += HandleDeath;
        health.OnDamageTaken += HandleGetHit;
    }

    private void OnDestroy()
    {
        enemyController.OnMeleeAttack -= HandleAttack;
        health.OnDie -= HandleDeath;
        health.OnDamageTaken -= HandleGetHit;
    }

    private void Update()
    {
        animator.SetFloat("Vertical", enemyController.ai.velocity.magnitude);
        animator.SetBool("CancelIdleAction", Input.anyKey);
        animator.SetBool("Grounded", true);
    }

    private void HandleAttack(Dictionary<string, AttackComponent> attacks)
    {
        animator.SetTrigger(attacks.Keys.ToList()[Random.Range(0,attacks.Count)]);
    }

    private void HandleGetHit()
    {
        if (Random.Range(0f, 100f) < 30)
            animator.Play("GetHit");
    }

    private void HandleDeath()
    {
        enemyController.ai.enabled = false;
        enemyController.GetComponentInChildren<FaceCamera>().gameObject.SetActive(false);
        animator.Play("Death");
    }

}
