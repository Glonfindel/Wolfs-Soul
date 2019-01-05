using UnityEngine;

public class SpawnEffectOnEnterBehaviour : IBehaviour
{

    private GameObject effect;
    public IStateMachine Machine { get; set; }

    public SpawnEffectOnEnterBehaviour(GameObject effect)
    {
        this.effect = effect;
    }

    public void Enter()
    {
        GameObject.Instantiate(effect, Machine.User.transform.position + Vector3.up, effect.transform.rotation);
    }

    public void Exit()
    {   
    }

    public void Update(float time)
    {
    }
}
