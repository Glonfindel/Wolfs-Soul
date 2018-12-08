using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WerewolfStateMachineAsset
{
    private void CreateRangeAttack(StateMachine stateMachine)
    {
        State state;
        Transition transition;

        state = new State("RangeAttack");
        stateMachine.AddState(state);
        state.AddBehaviour(new ExecuteAttackOnAnimCurveBehaviour(new AttackBehaviour("RangeAttackWerewolf")));
        state.AddBehaviour(new PlayAnimationBehaviour("RangeAttack", 0.1f));
        state.AddBehaviour(new DrainEnergyBehaviour(3));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
    }
}