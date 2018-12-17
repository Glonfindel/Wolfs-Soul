using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spider State Machine", menuName = "State Machines/Spider")]
public partial class SpiderStateMachineAsset : StateMachineAsset
{
    public override StateMachine Create(GameObject user)
    {
        StateMachine stateMachine = new StateMachine(user);

        CreateIdle(stateMachine);
        CreateWalkForward(stateMachine);
        CreateRotateRight(stateMachine);
        CreateRotateLeft(stateMachine);
        CreateAttack1(stateMachine);
        CreateGetHit(stateMachine);
        CreateDeath(stateMachine);

        return stateMachine;
    }
}
