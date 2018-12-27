using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : CombatComponent
{
    public AttackComponent Prefab;
    public float[] Angles;
    private bool initialized;

    protected void OnEnable()
    {
        if (!initialized)
        {
            initialized = true;
            return;
        }

        foreach (var angle in Angles)
        {
            Instantiate(Prefab, transform.position, Quaternion.Euler(0, transform.parent.eulerAngles.y + angle, 0));
        }
    }
}
