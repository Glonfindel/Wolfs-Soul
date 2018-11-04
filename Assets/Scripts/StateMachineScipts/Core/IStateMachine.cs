using UnityEngine;

public interface IStateMachine
{
    GameObject User { get; }
    IState CurrentState { get; }
    float StateTime { get; }
    void Update(float time);
    void ChangeState(string name);
}
