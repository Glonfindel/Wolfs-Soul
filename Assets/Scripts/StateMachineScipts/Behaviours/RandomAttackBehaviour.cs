using UnityEngine;

public class RandomAttackBehaviour : IBehaviour
{
    public IStateMachine Machine { get; set; }

    public void Enter()
    {
    }

    public void Exit()
    {
        Machine.User.GetComponent<EnemyController>().RandomAttack();
    }

    public void Update(float time)
    {
    }
}
