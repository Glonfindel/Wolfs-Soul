using UnityEngine;

public class PlayAnimationBehaviour : IBehaviour
{

    private string name;
    private float time;
    public IStateMachine Machine { get; set; }

    public PlayAnimationBehaviour(string name, float time)
    {
        this.name = name;
        this.time = time;
    }

    public void Enter()
    {
        Machine.User.GetComponentInChildren<Animator>().CrossFadeInFixedTime(name, time);
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
    }
}
