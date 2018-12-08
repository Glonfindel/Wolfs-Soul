using UnityEngine;

public class JumpBehaviour : IBehaviour
{

    private float power;
    public IStateMachine Machine { get; set; }

    public JumpBehaviour(float power)
    {
        this.power = power;
    }

    public void Enter()
    {
        Machine.User.GetComponent<Rigidbody>().AddForce(Machine.User.transform.forward * power + Vector3.up * power, ForceMode.Impulse);
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
    }
}
