using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UndeadStateMachineAsset
{
    private void CreateInactive(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Inactive");
        stateMachine.AddState(state);
        state.AddBehaviour(new SetAIOnEnterBehaviour(false));
        state.Enter();
        state.AddBehaviour(new PlayAnimationBehaviour("Inactive", 0));

        transition = new Transition("Active");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < 10f));
    }
}