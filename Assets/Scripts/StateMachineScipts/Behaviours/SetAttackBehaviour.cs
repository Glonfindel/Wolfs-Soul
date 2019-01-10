using UnityEngine;

public class SetAttackBehaviour : IBehaviour
{
    public IStateMachine Machine { get; set; }

    public void Enter()
    {
    }

    public void Exit()
    {
        Machine.User.GetComponent<EnemyController>().SetAttack();
    }

    public void Update(float time)
    {
    }
}
