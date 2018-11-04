using UnityEngine;

public class ExecuteAttackOnAnimCurveBehaviour : IBehaviour
{
    private IBehaviour behaviour;
    public IStateMachine Machine
    {
        get { return behaviour.Machine; }
        set { behaviour.Machine = value; }
    }

    public ExecuteAttackOnAnimCurveBehaviour(IBehaviour behaviour)
    {
        this.behaviour = behaviour;
    }

    public void Enter()
    {
        behaviour.Enter();
    }

    public void Exit()
    {
        behaviour.Exit();
    }

    public void Update(float time)
    {
        if (Machine.User.GetComponentInChildren<Animator>().GetFloat("AttackEnabled") > 0.5f)
        {
            behaviour.Update(time);
        }
    }
}
