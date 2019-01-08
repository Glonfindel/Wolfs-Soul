using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalAxisCondition : ICondition
{

    private Func<float, bool> checker;

    public HorizontalAxisCondition(Func<float, bool> checker)
    {
        this.checker = checker;
    }
    public bool Check(GameObject target)
    {
        return checker(target.GetComponent<CharacterController>().Input.Horizontal);
    }
}
