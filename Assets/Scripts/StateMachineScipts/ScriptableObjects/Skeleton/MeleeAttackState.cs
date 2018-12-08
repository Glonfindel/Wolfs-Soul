using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SkeletonStateMachineAsset
{
    private void CreateMeleeAttack(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("MeleeAttack");
        stateMachine.AddState(state);
        state.AddBehaviour(new ExecuteAttackOnAnimCurveBehaviour(new AttackBehaviour("MeleeAttack")));
        state.AddBehaviour(new PlayAnimationBehaviour("MeleeAttack", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}