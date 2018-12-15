using UnityEngine;

public class RotateAIBehaviour : IBehaviour
{

    private float speed;
    public IStateMachine Machine { get; set; }

    public RotateAIBehaviour(float speed)
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
        Vector3 direction = (CharacterController.Player.transform.position - Machine.User.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        Machine.User.transform.rotation = Quaternion.Slerp(Machine.User.transform.rotation, lookRotation, time * speed);
    }
}
