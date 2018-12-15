using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SkeletonStateMachineAsset
{
    private void CreateGetHit(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("GetHit");
        stateMachine.AddState(state);
        state.AddBehaviour(new PlayAnimationBehaviour("GetHit", 0f));

        transition = new Transition("Death");
        state.AddTransition(transition);
        transition.AddCondition(new IsDeadCondition());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}