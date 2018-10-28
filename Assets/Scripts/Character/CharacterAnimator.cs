using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{

    private Animator animator;
    private CharacterController characterController;
    private CharacterInput characterInput;
    private Health health;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterInput = GetComponent<CharacterInput>();
        characterController = GetComponent<CharacterController>();
        health = GetComponent<Health>();
        characterInput.OnMeleeAttack += HandleMeleeAttack;
        characterInput.OnRangeAttack += HandleRangeAttack;
        health.OnDie += HandleDeath;
        health.OnDamageTaken += HandleGetHit;
    }

    private void OnDestroy()
    { 
        characterInput.OnMeleeAttack -= HandleMeleeAttack;
        characterInput.OnRangeAttack -= HandleRangeAttack;
        health.OnDie -= HandleDeath;
        health.OnDamageTaken -= HandleGetHit;
    }

    private void Update()
    {
        animator.SetFloat("Vertical", characterInput.Vertical);
        animator.SetBool("Jump", characterInput.Jump);
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
