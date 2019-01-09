using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDeadCondition : ICondition
{
    public bool Check(GameObject target)
    {
        return target.GetComponent<Health>().HealthAsPercentage <= 0;
    }
}
