using UnityEngine;

public class TransformationBehaviour : IBehaviour
{
    
    private bool active;
    public IStateMachine Machine { get; set; }

    public TransformationBehaviour(bool active)
    {
        this.active = active;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
        Machine.User.GetComponent<CharacterController>().Transform(active);
    }

    public void Update(float time)
    {
    }
}
