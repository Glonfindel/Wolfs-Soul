using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WerewolfStateMachineAsset
{
    private void CreateJump(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Jump");
        stateMachine.AddState(state);
        state.AddBehaviour(new JumpBehaviour(5));
        state.AddBehaviour(new PlayAnimationBehaviour("Jump", 0.1f));
        state.AddBehaviour(new DrainEnergyBehaviour(3));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}