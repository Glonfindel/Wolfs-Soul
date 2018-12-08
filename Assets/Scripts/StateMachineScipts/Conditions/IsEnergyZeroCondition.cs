using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnergyZeroCondition : Condition
{
    public override bool Check(GameObject target)
    {
        return target.GetComponent<Energy>().EnergyAsPercentage <= 0;
    }
}
