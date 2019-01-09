using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCheckToPlayerCondition : ICondition
{

    private Func<float, bool> checker;

    public RangeCheckToPlayerCondition(Func<float, bool> checker)
    {
        this.checker = checker;
    }
    public bool Check(GameObject target)
    {
        return checker(Vector3.Distance(target.transform.position, CharacterController.Player.transform.position));
    }
}
