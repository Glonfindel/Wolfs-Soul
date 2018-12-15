using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleCheckToPlayerCondition : Condition
{

    private Func<float, bool> checker;

    public AngleCheckToPlayerCondition(Func<float, bool> checker)
    {
        this.checker = checker;
    }
    public override bool Check(GameObject target)
    {
        return checker(target.transform.InverseTransformPoint(CharacterController.Player.transform.position).x);
    }
}
