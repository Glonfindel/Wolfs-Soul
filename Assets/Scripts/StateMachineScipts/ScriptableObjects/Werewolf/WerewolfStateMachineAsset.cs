using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Werewolf State Machine", menuName = "State Machines/Werewolf")]
public partial class WerewolfStateMachineAsset : StateMachineAsset
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
        CreateMeleeAttack(stateMachine);
        CreateTransformation(stateMachine);
        CreateGetHit(stateMachine);
        CreateDeath(stateMachine);

        return stateMachine;
    }
}
