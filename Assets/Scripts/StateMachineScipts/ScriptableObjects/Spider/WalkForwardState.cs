using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SpiderStateMachineAsset
{
    private void CreateWalkForward(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("WalkForward");
        stateMachine.AddState(state);
        state.AddBehaviour(new MoveAIBehaviour());
        state.AddBehaviour(new PlayAnimationBehaviour("Run", 0.1f));
        state.AddBehaviour(new AggroAIBehaviour());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < stateMachine.User.GetComponent<EnemyController>().AI.stoppingDistance));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e > stateMachine.User.GetComponent<EnemyController>().lookRadius));
    }
}