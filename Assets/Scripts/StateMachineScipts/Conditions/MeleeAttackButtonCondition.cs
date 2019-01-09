using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackButtonCondition : ICondition
{
    public bool Check(GameObject target)
    {
        return target.GetComponent<CharacterController>().Input.MeleeAttack;
    }
}
