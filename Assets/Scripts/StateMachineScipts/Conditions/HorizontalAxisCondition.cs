using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalAxisCondition : Condition
{

    private Func<float, bool> checker;

    public HorizontalAxisCondition(Func<float, bool> checker)
    {
        this.checker = checker;
    }
    public override bool Check(GameObject target)
    {
        return checker(target.GetComponent<CharacterController>().Input.Horizontal);
    }
}
