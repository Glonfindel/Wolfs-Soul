using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DemonStateMachineAsset
{
    private void CreateAttack1(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Attack1");
        stateMachine.AddState(state);
        state.AddBehaviour(new ExecuteAttackOnAnimCurveBehaviour(new AttackBehaviour("Attack1")));
        state.AddBehaviour(new PlayAnimationBehaviour("Attack1", 0.1f));
        state.AddBehaviour(new SetAttackBehaviour());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}