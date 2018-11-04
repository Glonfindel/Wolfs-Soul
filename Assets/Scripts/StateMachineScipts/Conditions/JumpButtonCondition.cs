using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButtonCondition : Condition
{
    public override bool Check(GameObject target)
    {
        return target.GetComponent<CharacterController>().Input.Jump;
    }
}
