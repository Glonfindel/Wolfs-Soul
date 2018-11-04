public interface IBehaviour
{
    IStateMachine Machine { get; set; }
    void Enter();
    void Update(float time);
    void Exit();

}
