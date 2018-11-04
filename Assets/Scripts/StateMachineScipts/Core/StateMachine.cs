using System.Collections.Generic;
using UnityEngine;

public class StateMachine : IStateMachine
{
    private Dictionary<string, IState> states = new Dictionary<string, IState>();

    public GameObject User { get; private set; }
    public IState CurrentState { get; private set; }
    public float StateTime { get; private set; }

    public StateMachine(GameObject user)
    {
        User = user;
    }

    public void Update(float time)
    {
        StateTime += time;
        CurrentState.Update(time);
    }

    public void ChangeState(string name)
    {
        CurrentState.Exit();
        StateTime = 0;
        CurrentState = states[name];
        CurrentState.Enter();
    }

    public void AddState(IState state)
    {
        state.Machine = this;
        states.Add(state.Name, state);
        if (CurrentState == null)
        {
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}
