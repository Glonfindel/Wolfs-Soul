using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFinishedCondition : Condition
{
    public override bool Check(GameObject target)
    {
        return target.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1;
    }
}
