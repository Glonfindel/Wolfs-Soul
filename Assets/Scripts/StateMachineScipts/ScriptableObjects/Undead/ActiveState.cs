using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UndeadStateMachineAsset
{
    private void CreateActive(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Active");
        stateMachine.AddState(state);
        state.AddBehaviour(new PlayAnimationBehaviour("Active", 0));
        state.AddBehaviour(new SetAIOnExitBehaviour(true));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}