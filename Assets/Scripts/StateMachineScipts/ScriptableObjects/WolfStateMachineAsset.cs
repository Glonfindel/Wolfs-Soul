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
        state.AddBehaviour(new PlayAnimationBehaviour("Idle"));

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
        transition.AddCondition(new JumpButtonCondition());
        transition.AddCondition(new IsGroundedCondition());

        transition = new Transition("MeleeAttack");
        state.AddTransition(transition);
        transition.AddCondition(new MeleeAttackButtonCondition());

        #endregion

        #region WalkForwardState

        state = new State("WalkForward");
        stateMachine.AddState(state);
        state.AddBehaviour(new MoveBehaviour(5f));
        state.AddBehaviour(new RotateBehaviour(75f));
        state.AddBehaviour(new PlayAnimationBehaviour("Run"));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e == 0));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new JumpButtonCondition());
        transition.AddCondition(new IsGroundedCondition());

        #endregion

        #region WalkBackwardState

        state = new State("WalkBackward");
        stateMachine.AddState(state);
        state.AddBehaviour(new MoveBehaviour(-3f));
        state.AddBehaviour(new RotateBehaviour(75f));
        state.AddBehaviour(new PlayAnimationBehaviour("Walk"));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new VerticalAxisCondition(e => e == 0));

        transition = new Transition("Jump");
        state.AddTransition(transition);
        transition.AddCondition(new JumpButtonCondition());
        transition.AddCondition(new IsGroundedCondition());

        #endregion

        #region RotateRightState

        state = new State("RotateRight");
        stateMachine.AddState(state);
        state.AddBehaviour(new RotateBehaviour(100f));
        state.AddBehaviour(new PlayAnimationBehaviour("Rotate Right"));

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
        transition.AddCondition(new JumpButtonCondition());
        transition.AddCondition(new IsGroundedCondition());

        #endregion

        #region RotateLeftState

        state = new State("RotateLeft");
        stateMachine.AddState(state);
        state.AddBehaviour(new RotateBehaviour(100f));
        state.AddBehaviour(new PlayAnimationBehaviour("Rotate Left"));

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
        transition.AddCondition(new JumpButtonCondition());
        transition.AddCondition(new IsGroundedCondition());

        #endregion

        #region JumpState

        state = new State("Jump");
        stateMachine.AddState(state);
        state.AddBehaviour(new JumpBehaviour(10));
        state.AddBehaviour(new PlayAnimationBehaviour("Jump"));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());

        #endregion

        #region MeleeAttackState

        state = new State("MeleeAttack");
        stateMachine.AddState(state);
        state.AddBehaviour(new ExecuteAttackOnAnimCurveBehaviour(new AttackBehaviour("MeleeAttack")));
        state.AddBehaviour(new PlayAnimationBehaviour("MeleeAttack"));

        transition = new Transition("Idle");
        state.AddTransition(transition);
        transition.AddCondition(new AnimationFinishedCondition());

        #endregion

        return stateMachine;
    }
}
