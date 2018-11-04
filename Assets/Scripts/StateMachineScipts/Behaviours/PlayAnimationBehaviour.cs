using UnityEngine;

public class PlayAnimationBehaviour : IBehaviour
{

    private string name;
    public IStateMachine Machine { get; set; }

    public PlayAnimationBehaviour(string name)
    {
        this.name = name;
    }

    public void Enter()
    {
        Machine.User.GetComponentInChildren<Animator>().CrossFadeInFixedTime(name, 0.1f);
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
    }
}
