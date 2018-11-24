using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wolf State Machine", menuName = "State Machines/Wolf")]
public class WolfStateMachineAsset : StateMachineAsset
{
    public override StateMachine Create(GameObject user)
    {
        StateMachine stateMachine = new StateMachine(user);
        State state;
        Transition transition;

        #region IdleState

        state = new State("Idle");
        stateMachine.AddState(state);
        state.AddBehaviour(new PlayAnimationBehaviour("Idle", 0.1f));

        transition = new Transition("WalkForward");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e > 0));

        transition = new Transition("WalkBackward");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e < 0));

        transition = new Transition("RotateRight");
        state.AddTransition(transition);
        transition.AddCondition(new HorizontalAxisCondition(e => e > 0));

        transition = new Transition("RotateLeft");
        state.AddTransition(transition);
        transition.AddCondition(new HorizontalAxisCondition(e => e < 0));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Jump"));
        transition.AddCondition(new IsGroundedCondition());

        transition = new Transition("MeleeAttack");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("MeleeAttack"));

        transition = new Transition("RangeAttack");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("RangeAttack"));

        transition = new Transition("Transformation");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Transformation"));

        #endregion

        #region WalkForwardState

        state = new State("WalkForward");
        stateMachine.AddState(state);
        state.AddBehaviour(new MoveBehaviour(5f));
        state.AddBehaviour(new RotateBehaviour(75f));
        state.AddBehaviour(new PlayAnimationBehaviour("Run", 0.1f));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Jump"));
        transition.AddCondition(new IsGroundedCondition());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e == 0));
        
        #endregion

        #region WalkBackwardState

        state = new State("WalkBackward");
        stateMachine.AddState(state);
        state.AddBehaviour(new MoveBehaviour(-3f));
        state.AddBehaviour(new RotateBehaviour(75f));
        state.AddBehaviour(new PlayAnimationBehaviour("Walk", 0.1f));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Jump"));
        transition.AddCondition(new IsGroundedCondition());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e == 0));

        #endregion

        #region RotateRightState

        state = new State("RotateRight");
        stateMachine.AddState(state);
        state.AddBehaviour(new RotateBehaviour(100f));
        state.AddBehaviour(new PlayAnimationBehaviour("Rotate Right", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new HorizontalAxisCondition(e => e == 0));

        transition = new Transition("WalkForward");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e > 0));

        transition = new Transition("WalkBackward");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e < 0));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Jump"));
        transition.AddCondition(new IsGroundedCondition());

        #endregion

        #region RotateLeftState

        state = new State("RotateLeft");
        stateMachine.AddState(state);
        state.AddBehaviour(new RotateBehaviour(100f));
        state.AddBehaviour(new PlayAnimationBehaviour("Rotate Left", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new HorizontalAxisCondition(e => e == 0));

        transition = new Transition("WalkForward");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e > 0));

        transition = new Transition("WalkBackward");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e < 0));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new ButtonCondition("Jump"));
        transition.AddCondition(new IsGroundedCondition());

        #endregion

        #region JumpState

        state = new State("Jump");
        stateMachine.AddState(state);
        state.AddBehaviour(new JumpBehaviour(10));
        state.AddBehaviour(new PlayAnimationBehaviour("Jump", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());

        #endregion

        #region DodgeState

        state = new State("Dodge");
        stateMachine.AddState(state);
        state.AddBehaviour(new JumpBehaviour(-10));
        state.AddBehaviour(new PlayAnimationBehaviour("Dodge", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());

        #endregion

        #region MeleeAttackState

        state = new State("MeleeAttack");
        stateMachine.AddState(state);
        state.AddBehaviour(new ExecuteAttackOnAnimCurveBehaviour(new AttackBehaviour("MeleeAttack")));
        state.AddBehaviour(new PlayAnimationBehaviour("MeleeAttack", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());

        #endregion

        #region RangeAttackState

        state = new State("RangeAttack");
        stateMachine.AddState(state);
        state.AddBehaviour(new ExecuteAttackOnAnimCurveBehaviour(new AttackBehaviour("RangeAttack")));
        state.AddBehaviour(new PlayAnimationBehaviour("RangeAttack", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());

        #endregion

        #region TransformationState

        state = new State("Transformation");
        stateMachine.AddState(state);
        state.AddBehaviour(new PlayAnimationBehaviour("Transformation", 0.1f));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());

        #endregion

        #region GetHitState

        state = new State("GetHit");
        stateMachine.AddState(state);
        state.AddBehaviour(new PlayAnimationBehaviour("GetHit", 0f));

        transition = new Transition("Death");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());
        transition.AddCondition(new IsDeadCondition());

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());

        #endregion

        #region DeathState

        state = new State("Death");
        stateMachine.AddState(state);
        state.AddBehaviour(new PlayAnimationBehaviour("Death", 0.1f));

        #endregion

        return stateMachine;
    }
}
