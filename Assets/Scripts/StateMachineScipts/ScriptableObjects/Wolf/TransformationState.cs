using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WolfStateMachineAsset
{
    private void CreateTransformation(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Transformation");
        stateMachine.AddState(state);
        state.AddBehaviour(new PlayAnimationBehaviour("Transformation", 0.1f));
        state.AddBehaviour(new TransformationBehaviour(true));
        state.AddBehaviour(new SpawnEffectOnEnterBehaviour(Resources.Load<GameObject>("SFX/Howl")));
        state.AddBehaviour(new SpawnEffectOnExitBehaviour(Resources.Load<GameObject>("TransformationEffect")));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}