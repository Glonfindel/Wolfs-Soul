using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{

    private Animator animator;
    private CharacterController characterController;
    private Health health;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        health = GetComponent<Health>();
        characterController.Input.OnMeleeAttack += HandleMeleeAttack;
        characterController.Input.OnRangeAttack += HandleRangeAttack;
        health.OnDie += HandleDeath;
        health.OnDamageTaken += HandleGetHit;
    }

    private void OnDestroy()
    {
        characterController.Input.OnMeleeAttack -= HandleMeleeAttack;
        characterController.Input.OnRangeAttack -= HandleRangeAttack;
        health.OnDie -= HandleDeath;
        health.OnDamageTaken -= HandleGetHit;
    }

    private void Update()
    {
        animator.SetFloat("Vertical", characterController.Input.Vertical);
        animator.SetBool("Jump", characterController.Input.Jump);
        animator.SetBool("Dodge", characterController.Input.Dodge);
        animator.SetBool("CancelIdleAction", Input.anyKey);
        animator.SetBool("Grounded", characterController.IsGrounded);
    }

    private void HandleMeleeAttack()
    {
        animator.SetTrigger("MeleeAttack");
    }

    private void HandleRangeAttack()
    {
        animator.SetTrigger("RangeAttack");
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
