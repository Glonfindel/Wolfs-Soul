using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WolfStateMachineAsset
{
    private void CreateRotateLeft(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("RotateLeft");
        stateMachine.AddState(state);
        state.AddBehaviour(new RotateBehaviour(100f));
        state.AddBehaviour(new PlayAnimationBehaviour("Rotate Left", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new HorizontalAxisCondition(e => e == 0));

        transition = new Transition("WalkForward");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e > 0));

        transition = new Transition("WalkBackward");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e < 0));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Jump"));
        transition.AddCondition(new IsGroundedCondition());
    }
}