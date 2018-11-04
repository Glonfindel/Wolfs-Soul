using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineAsset : ScriptableObject
{
    public abstract StateMachine Create(GameObject user);

}
