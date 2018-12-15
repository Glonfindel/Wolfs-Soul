using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skeleton State Machine", menuName = "State Machines/Skeleton")]
public partial class SkeletonStateMachineAsset : StateMachineAsset
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
        CreateMeleeAttack(stateMachine);
        CreateGetHit(stateMachine);
        CreateDeath(stateMachine);

        return stateMachine;
    }
}
