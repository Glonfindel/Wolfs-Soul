using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wolf State Machine", menuName = "State Machines/Wolf")]
public partial class WolfStateMachineAsset : StateMachineAsset
{
    public override StateMachine Create(GameObject user)
    {
        StateMachine stateMachine = new StateMachine(user);

        CreateIdle(stateMachine);
        CreateWalkForward(stateMachine);
        CreateWalkBackward(stateMachine);
        CreateRotateRight(stateMachine);
        CreateRotateLeft(stateMachine);
        CreateJump(stateMachine);
        CreateDodge(stateMachine);
        CreateMeleeAttack(stateMachine);
        CreateRangeAttack(stateMachine);
        CreateTransformation(stateMachine);
        CreateGetHit(stateMachine);
        CreateDeath(stateMachine);

        return stateMachine;
    }
}
