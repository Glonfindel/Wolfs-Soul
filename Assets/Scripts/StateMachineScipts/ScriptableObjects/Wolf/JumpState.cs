using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WolfStateMachineAsset
{
    private void CreateJump(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Jump");
        stateMachine.AddState(state);
        state.AddBehaviour(new JumpBehaviour(10));
        state.AddBehaviour(new PlayAnimationBehaviour("Jump", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}