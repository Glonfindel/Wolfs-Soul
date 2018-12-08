using UnityEngine;

public class DodgeBehaviour : IBehaviour
{

    private float power;
    public IStateMachine Machine { get; set; }

    public DodgeBehaviour(float power)
    {
        this.power = power;
    }

    public void Enter()
    {
        Machine.User.GetComponent<Rigidbody>().AddForce(Machine.User.transform.forward * power, ForceMode.Impulse);
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
    }
}
