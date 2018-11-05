using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCondition : Condition
{
    private string buttonName;

    public ButtonCondition(string buttonName)
    {
        this.buttonName = buttonName;
    }

    public override bool Check(GameObject target)
    {
        return Input.GetButtonDown(buttonName);
    }
}
