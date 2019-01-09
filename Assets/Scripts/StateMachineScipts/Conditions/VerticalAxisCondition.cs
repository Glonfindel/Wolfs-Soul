using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalAxisCondition : ICondition
{

    private Func<float, bool> checker;

    public VerticalAxisCondition(Func<float, bool> checker)
    {
        this.checker = checker;
    }
    public bool Check(GameObject target)
    {
        return checker(target.GetComponent<CharacterController>().Input.Vertical);
    }
}
