using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Undead State Machine", menuName = "State Machines/Undead")]
public partial class UndeadStateMachineAsset : StateMachineAsset
{
    public override StateMachine Create(GameObject user)
    {
        StateMachine stateMachine = new StateMachine(user);

        CreateInactive(stateMachine);
        CreateActive(stateMachine);
        CreateIdle(stateMachine);
        CreateWalkForward(stateMachine);
        CreateRotateRight(stateMachine);
        CreateRotateLeft(stateMachine);
        CreateAttack1(stateMachine);
        CreateAttack2(stateMachine);
        CreateAttack3(stateMachine);
        CreateGetHit(stateMachine);
        CreateDeath(stateMachine);

        return stateMachine;
    }
}
