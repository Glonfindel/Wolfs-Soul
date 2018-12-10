using UnityEngine;

public class SpawnEffectOnExitBehaviour : IBehaviour
{

    private GameObject effect;
    public IStateMachine Machine { get; set; }

    public SpawnEffectOnExitBehaviour(GameObject effect)
    {
        this.effect = effect;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
        GameObject.Instantiate(effect, Machine.User.transform.position + Vector3.up, effect.transform.rotation);
    }

    public void Update(float time)
    {
    }
}
