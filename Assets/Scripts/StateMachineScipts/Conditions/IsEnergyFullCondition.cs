using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnergyFullCondition : ICondition
{
    public bool Check(GameObject target)
    {
        return target.GetComponent<Energy>().EnergyAsPercentage >= 1;
    }
}
