using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WolfStateMachineAsset
{
    private void CreateIdle(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Idle");
        stateMachine.AddState(state);
        state.AddBehaviour(new PlayAnimationBehaviour("Idle", 0.1f));

        transition = new Transition("WalkForward");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e > 0));

        transition = new Transition("WalkBackward");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e < 0));

        transition = new Transition("RotateRight");
        state.AddTransition(transition);
        transition.AddCondition(new HorizontalAxisCondition(e => e > 0));

        transition = new Transition("RotateLeft");
        state.AddTransition(transition);
        transition.AddCondition(new HorizontalAxisCondition(e => e < 0));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Jump"));
        transition.AddCondition(new IsGroundedCondition());

        transition = new Transition("Dodge");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Dodge"));
        transition.AddCondition(new IsGroundedCondition());

        transition = new Transition("MeleeAttack");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("MeleeAttack"));

        transition = new Transition("RangeAttack");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("RangeAttack"));

        transition = new Transition("Transformation");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Transformation"));
        transition.AddCondition(new IsEnergyFullCondition());
    }
}