using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButtonCondition : ICondition
{
    public bool Check(GameObject target)
    {
        return target.GetComponent<CharacterController>().Input.Jump;
    }
}
