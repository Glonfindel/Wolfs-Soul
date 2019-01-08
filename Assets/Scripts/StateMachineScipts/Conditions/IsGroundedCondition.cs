using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedCondition : ICondition
{
    public bool Check(GameObject target)
    {
        return Physics.Raycast(target.transform.position + new Vector3(0, 0.05f, 0), Vector3.down, 0.1f);
    }
}
