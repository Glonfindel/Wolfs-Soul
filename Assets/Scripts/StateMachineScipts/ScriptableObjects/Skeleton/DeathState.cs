using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SkeletonStateMachineAsset
{
    private void CreateDeath(StateMachine stateMachine)
    {
        State state;

        state = new State("Death");
        stateMachine.AddState(state);
        state.AddBehaviour(new PlayAnimationBehaviour("Death", 0.1f));
    }
}