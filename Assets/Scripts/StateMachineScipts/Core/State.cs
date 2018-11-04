using System.Collections.Generic;

public class State : IState
{
    private readonly List<Transition> transitions = new List<Transition>();
    private List<IBehaviour> behaviours = new List<IBehaviour>();
    public IStateMachine Machine { get; set; }
    public string Name { get; private set; }

    public State(string name)
    {
        Name = name;
    }

    public void Enter()
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.Enter();
        }
    }

    public void Update(float time)
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.Update(time);
        }
        foreach (var transition in transitions)
        {
            if (transition.CheckAll(Machine))
            {
                break;
            }
        }
    }

    public void Exit()
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.Exit();
        }
    }

    public void AddTransition(Transition transition)
    {
        transitions.Add(transition);
    }

    public void AddBehaviour(IBehaviour behaviour)
    {
        behaviour.Machine = Machine;
        behaviours.Add(behaviour);
    }
}
