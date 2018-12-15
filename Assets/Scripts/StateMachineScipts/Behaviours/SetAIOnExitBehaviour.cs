using UnityEngine;
using UnityEngine.AI;

public class SetAIOnExitBehaviour : IBehaviour
{
    public IStateMachine Machine { get; set; }
    private bool active;

    public SetAIOnExitBehaviour(bool active)
    {
        this.active = active;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
        Machine.User.GetComponent<EnemyController>().Collider.enabled = active;
        Machine.User.GetComponent<EnemyController>().UI.gameObject.SetActive(active);
    }

    public void Update(float time)
    {
    }
}
