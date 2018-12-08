﻿using System.Collections;
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

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}