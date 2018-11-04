using UnityEngine;

public class RotateBehaviour : IBehaviour
{

    private float speed;
    public IStateMachine Machine { get; set; }

    public RotateBehaviour(float speed)
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
        Machine.User.transform.Rotate(Vector3.up * Machine.User.GetComponent<CharacterController>().Input.Horizontal * time * speed);
    }
}
