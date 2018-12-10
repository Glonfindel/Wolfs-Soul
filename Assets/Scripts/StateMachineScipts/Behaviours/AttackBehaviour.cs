using UnityEngine;

public class AttackBehaviour : IBehaviour
{

    private string name;
    public IStateMachine Machine { get; set; }

    public AttackBehaviour(string name)
    {
        this.name = name;
    }

    public void Enter()
    {
        Machine.User.GetComponent<Controller>().SetAllAttacksActive(false);
    }

    public void Exit()
    {
        Machine.User.GetComponent<Controller>().SetAllAttacksActive(false);
    }

    public void Update(float time)
    {
        Machine.User.GetComponent<Controller>().SetAttackActive(name);
    }
}
