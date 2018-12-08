using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnergyFullCondition : Condition
{
    public override bool Check(GameObject target)
    {
        return target.GetComponent<Energy>().EnergyAsPercentage >= 1;
    }
}
