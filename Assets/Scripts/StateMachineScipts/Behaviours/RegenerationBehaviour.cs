using UnityEngine;

public class RegenerationBehaviour : IBehaviour
{
    private Health health;
    private float multiplier;
    private float startTime;
    public IStateMachine Machine { get; set; }

    public RegenerationBehaviour(GameObject go, float multiplier)
    {
        this.health = go.GetComponent<Health>();
        this.multiplier = multiplier;
    }

    public void Enter()
    {
        startTime = Time.time + 2;
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
        if (startTime < Time.time)
            health.Heal(time * multiplier);
    }
}
