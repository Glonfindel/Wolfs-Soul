public class SetAIOnEnterBehaviour : IBehaviour
{
    public IStateMachine Machine { get; set; }
    private bool active;

    public SetAIOnEnterBehaviour(bool active)
    {
        this.active = active;
    }

    public void Enter()
    {
        Machine.User.GetComponent<EnemyController>().Collider.enabled = active;
        Machine.User.GetComponent<EnemyController>().UI.gameObject.SetActive(active);
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
    }
}
