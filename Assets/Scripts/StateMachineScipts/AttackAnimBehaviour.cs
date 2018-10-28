using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackAnimBehaviour : StateMachineBehaviour
{
    public string AttackName = "MeleeAttack";

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CharacterController character = animator.GetComponentInParent<CharacterController>();
        if (character)
        {
            character.SetAllAttacksActive(false);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CharacterController character = animator.GetComponentInParent<CharacterController>();
        if (character && !animator.IsInTransition(0))
        {
            if (!string.IsNullOrEmpty(AttackName))
            {
                character.SetAttackActive(AttackName, animator.GetFloat("AttackEnabled") > 0.5f);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CharacterController character = animator.GetComponentInParent<CharacterController>();
        if (character)
        {
            character.SetAllAttacksActive(false);
        }
    }
}
