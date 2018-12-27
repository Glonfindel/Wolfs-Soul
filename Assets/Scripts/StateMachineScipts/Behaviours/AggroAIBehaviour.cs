using UnityEngine;
using UnityEngine.AI;

public class AggroAIBehaviour : IBehaviour
{
    public IStateMachine Machine { get; set; }

    public void Enter()
    {
        Machine.User.GetComponent<EnemyController>().lookRadius = float.PositiveInfinity;
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
    }
}
