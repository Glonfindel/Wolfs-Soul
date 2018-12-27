using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DemonStateMachineAsset
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

        transition = new Transition("Attack1");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < stateMachine.User.GetComponent<EnemyController>().AI.stoppingDistance));
        transition.AddCondition(new AngleCheckToPlayerCondition(e => e < 0.1f && e > -0.1f));
        transition.AddCondition(new AttackAICondition("Attack1"));

        transition = new Transition("Attack2");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < stateMachine.User.GetComponent<EnemyController>().AI.stoppingDistance));
        transition.AddCondition(new AngleCheckToPlayerCondition(e => e < 0.1f && e > -0.1f));
        transition.AddCondition(new AttackAICondition("Attack2"));

        transition = new Transition("Attack3");
        state.AddTransition(transition);
        transition.AddCondition(new RangeCheckToPlayerCondition(e => e < stateMachine.User.GetComponent<EnemyController>().AI.stoppingDistance));
        transition.AddCondition(new AngleCheckToPlayerCondition(e => e < 0.1f && e > -0.1f));
        transition.AddCondition(new AttackAICondition("Attack3"));
    }
}