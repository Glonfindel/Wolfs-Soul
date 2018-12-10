using UnityEngine;

public class PlayAnimationChanceBehaviour : IBehaviour
{
    private IBehaviour behaviour;
    public IStateMachine Machine
    {
        get { return behaviour.Machine; }
        set { behaviour.Machine = value; }
    }

    public PlayAnimationChanceBehaviour(IBehaviour behaviour)
    {
        this.behaviour = behaviour;
    }

    public void Enter()
    {
        if (Random.Range(0f, 100f) < 30)
        {
            behaviour.Enter();
        }
    }

    public void Update(float time)
    {
        behaviour.Update(time);
    }

    public void Exit()
    {
        behaviour.Exit();
    }

}
