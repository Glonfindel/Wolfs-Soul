using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WolfStateMachineAsset
{
    private void CreateDodge(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Dodge");
        stateMachine.AddState(state);
        state.AddBehaviour(new JumpBehaviour(-10));
        state.AddBehaviour(new PlayAnimationBehaviour("Dodge", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}