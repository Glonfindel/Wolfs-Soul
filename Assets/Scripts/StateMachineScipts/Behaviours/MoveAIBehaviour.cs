using UnityEngine;
using UnityEngine.AI;

public class MoveAIBehaviour : IBehaviour
{
    public IStateMachine Machine { get; set; }

    public void Enter()
    {
    }

    public void Exit()
    {
        Machine.User.GetComponent<NavMeshAgent>().ResetPath();
    }

    public void Update(float time)
    {
        Machine.User.GetComponent<NavMeshAgent>().SetDestination(CharacterController.Player.transform.position);
    }
}
