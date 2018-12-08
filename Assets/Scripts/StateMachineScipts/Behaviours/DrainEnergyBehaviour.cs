using UnityEngine;

public class DrainEnergyBehaviour : IBehaviour
{

    private float value;
    public IStateMachine Machine { get; set; }

    public DrainEnergyBehaviour(float value)
    {
        this.value = value;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void Update(float time)
    {
        Machine.User.GetComponent<Energy>().CurrentEnergy -= value * time;
    }
}
