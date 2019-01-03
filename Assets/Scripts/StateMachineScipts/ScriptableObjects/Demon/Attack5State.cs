using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DemonStateMachineAsset
{
    private void CreateAttack5(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Attack5");
        stateMachine.AddState(state);
        state.AddBehaviour(new ExecuteAttackOnAnimCurveBehaviour(new AttackBehaviour("Attack5")));
        state.AddBehaviour(new PlayAnimationBehaviour("Attack5", 0.1f));
        state.AddBehaviour(new RandomAttackBehaviour());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}