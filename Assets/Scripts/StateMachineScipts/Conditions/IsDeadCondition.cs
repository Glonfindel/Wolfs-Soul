using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDeadCondition : Condition
{
    public override bool Check(GameObject target)
    {
        return target.GetComponent<Health>().HealthAsPercentage <= 0;
    }
}
