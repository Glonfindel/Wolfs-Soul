using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCondition : ICondition
{
    private string buttonName;

    public ButtonCondition(string buttonName)
    {
        this.buttonName = buttonName;
    }

    public bool Check(GameObject target)
    {
        return Input.GetButtonDown(buttonName);
    }
}
