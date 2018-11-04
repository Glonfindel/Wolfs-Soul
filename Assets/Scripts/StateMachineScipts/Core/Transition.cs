using System.Collections.Generic;

public class Transition
{
    private List<Condition> conditions = new List<Condition>();
    private string nextState;

    public Transition(string nextState)
    {
        this.nextState = nextState;
    }

    public bool CheckAll(IStateMachine machine)
    {
        foreach (var condition in conditions)
        {
            if (!condition.Check(machine.User))
            {
                return false;
            }
        }

        machine.ChangeState(nextState);
        return true;
    }

    public void AddCondition(Condition condition)
    {
        conditions.Add(condition);
    }
}
