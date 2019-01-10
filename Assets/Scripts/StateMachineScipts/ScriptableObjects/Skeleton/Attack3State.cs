using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SkeletonStateMachineAsset
{
    private void CreateAttack3(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Attack3");
        stateMachine.AddState(state);
        state.AddBehaviour(new ExecuteAttackOnAnimCurveBehaviour(new AttackBehaviour("Attack3")));
        state.AddBehaviour(new PlayAnimationBehaviour("Attack3", 0.1f));
        state.AddBehaviour(new SetAttackBehaviour());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}