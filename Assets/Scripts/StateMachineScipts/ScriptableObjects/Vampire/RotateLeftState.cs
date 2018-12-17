using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class VampireStateMachineAsset
{
    private void CreateRotateLeft(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("RotateLeft");
        stateMachine.AddState(state);
        state.AddBehaviour(new RotateAIBehaviour(5f));
        state.AddBehaviour(new PlayAnimationBehaviour("Rotate Left", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < stateMachine.User.GetComponent<EnemyController>().AI.stoppingDistance));
        transition.AddCondition(new AngleCheckToPlayerCondition(e => e < 0.1f && e > -0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e > stateMachine.User.GetComponent<EnemyController>().lookRadius));
        transition.AddCondition(new AngleCheckToPlayerCondition(e => e < 0.1f && e > -0.1f));

        transition = new Transition("WalkForward");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < stateMachine.User.GetComponent<EnemyController>().lookRadius));
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e > stateMachine.User.GetComponent<EnemyController>().AI.stoppingDistance));
    }
}