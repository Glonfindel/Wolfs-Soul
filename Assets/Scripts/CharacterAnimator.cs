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
        health.OnDie += HandleDeath;
    }

    private void OnDestroy()
    {
        health.OnDie -= HandleDeath;
    }

    private void Update()
    {
        animator.SetFloat("Vertical", characterInput.Vertical);
        animator.SetBool("Jump", characterController.IsGrounded && characterInput.Jump);
        animator.SetBool("CancelIdleAction", Input.anyKey);
        animator.SetBool("Grounded", characterController.IsGrounded);
    }

    private void HandleDeath()
    {
        animator.Play("Death");
    }

}
