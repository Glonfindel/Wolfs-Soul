using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DemonStateMachineAsset
{
    private void CreateAttack4(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Attack4");
        stateMachine.AddState(state);
        state.AddBehaviour(new ExecuteAttackOnAnimCurveBehaviour(new AttackBehaviour("Attack4")));
        state.AddBehaviour(new PlayAnimationBehaviour("Attack4", 0.1f));
        state.AddBehaviour(new RandomAttackBehaviour());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}