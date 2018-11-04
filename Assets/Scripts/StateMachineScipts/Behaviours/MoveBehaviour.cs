using UnityEngine;

public class MoveBehaviour : IBehaviour
{

    private float speed;
    public IStateMachine Machine { get; set; }

    public MoveBehaviour(float speed)
    {
        this.speed = speed;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
        Machine.User.transform.Translate(Vector3.forward * time * speed);
    }
}
