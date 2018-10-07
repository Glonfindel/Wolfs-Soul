using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement characterMovement;
    private CharacterInput characterInput;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterInput = GetComponent<CharacterInput>();
        characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        animator.SetFloat("Vertical", characterInput.Vertical);
        animator.SetBool("Jump", characterMovement.IsGrounded && characterInput.Jump);
        animator.SetBool("CancelIdleAction", Input.anyKey);
    }
}
