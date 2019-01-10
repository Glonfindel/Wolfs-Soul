using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Demon State Machine", menuName = "State Machines/Demon")]
public partial class DemonStateMachineAsset : StateMachineAsset
{
    public override StateMachine Create(GameObject user)
    {
        StateMachine stateMachine = new StateMachine(user);

        CreateIdle(stateMachine);
        CreateWalkForward(stateMachine);
        CreateRotateRight(stateMachine);
        CreateRotateLeft(stateMachine);
        CreateAttack1(stateMachine);
        CreateAttack2(stateMachine);
        CreateAttack3(stateMachine);
        CreateAttack4(stateMachine);
        CreateAttack5(stateMachine);
        CreateAttack6(stateMachine);
        CreateGetHit(stateMachine);
        CreateDeath(stateMachine);

        return stateMachine;
    }
}
