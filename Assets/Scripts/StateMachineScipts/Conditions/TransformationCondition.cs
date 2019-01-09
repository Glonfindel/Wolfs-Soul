using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationCondition : ICondition
{
    public bool Check(GameObject target)
    {
        return target.GetComponent<CharacterController>().Input.Transformation;
    }
}
