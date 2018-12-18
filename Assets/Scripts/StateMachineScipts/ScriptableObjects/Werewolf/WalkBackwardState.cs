using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WerewolfStateMachineAsset
{
    private void CreateWalkBackward(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("WalkBackward");
        stateMachine.AddState(state);
        state.AddBehaviour(new MoveBehaviour(-3f));
        state.AddBehaviour(new RotateBehaviour(75f));
        state.AddBehaviour(new PlayAnimationBehaviour("Walk", 0.1f));
        state.AddBehaviour(new DrainEnergyBehaviour(3));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Jump"));
        transition.AddCondition(new IsGroundedCondition());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e == 0));

        transition = new Transition("Transformation");
        state.AddTransition(transition);
        transition.AddCondition(new IsEnergyZeroCondition());
    }
}