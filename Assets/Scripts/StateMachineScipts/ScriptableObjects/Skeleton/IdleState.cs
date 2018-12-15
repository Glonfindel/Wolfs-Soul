using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SkeletonStateMachineAsset
{
    private void CreateIdle(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("Idle");
        stateMachine.AddState(state);
        state.AddBehaviour(new PlayAnimationBehaviour("Idle", 0.1f));

        transition = new Transition("WalkForward");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < stateMachine.User.GetComponent<EnemyController>().lookRadius));
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e > stateMachine.User.GetComponent<EnemyController>().AI.stoppingDistance));

        transition = new Transition("RotateRight");
        state.AddTransition(transition);
        transition.AddCondition(new AngleCheckToPlayerCondition(e => e > 0.1f));
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < stateMachine.User.GetComponent<EnemyController>().lookRadius));

        transition = new Transition("RotateLeft");
        state.AddTransition(transition);
        transition.AddCondition(new AngleCheckToPlayerCondition(e => e < -0.1f));
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < stateMachine.User.GetComponent<EnemyController>().lookRadius));

        /*transition = new Transition("MeleeAttack");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < stateMachine.User.GetComponent<EnemyController>().ai.stoppingDistance));*/
    }
}