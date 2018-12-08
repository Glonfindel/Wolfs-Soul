using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WolfStateMachineAsset
{
    private void CreateWalkForward(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("WalkForward");
        stateMachine.AddState(state);
        state.AddBehaviour(new MoveBehaviour(5f));
        state.AddBehaviour(new RotateBehaviour(75f));
        state.AddBehaviour(new PlayAnimationBehaviour("Run", 0.1f));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Jump"));
        transition.AddCondition(new IsGroundedCondition());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e == 0));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Jump"));
        transition.AddCondition(new IsGroundedCondition());

        transition = new Transition("MeleeAttack");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("MeleeAttack"));

        transition = new Transition("RangeAttack");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("RangeAttack"));
    }
}