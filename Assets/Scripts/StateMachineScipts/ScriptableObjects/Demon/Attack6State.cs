using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DemonStateMachineAsset
{
    private void CreateAttack6(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Attack6");
        stateMachine.AddState(state);
        state.AddBehaviour(new ExecuteAttackOnAnimCurveBehaviour(new AttackBehaviour("Attack6")));
        state.AddBehaviour(new PlayAnimationBehaviour("Attack6", 0.1f));
        state.AddBehaviour(new SetAttackBehaviour());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}