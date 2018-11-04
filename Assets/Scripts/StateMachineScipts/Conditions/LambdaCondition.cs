using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambdaCondition : Condition
{

    private Func<bool> checker;

    public LambdaCondition(Func<bool> checker)
    {
        this.checker = checker;
    }
    public override bool Check(GameObject target)
    {
        return checker();
    }
}
