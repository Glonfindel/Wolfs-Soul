using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFinishedCondition : ICondition
{
    public bool Check(GameObject target)
    {
        var animator = target.GetComponentInChildren<Animator>();
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0);
    }
}
