using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : CombatComponent
{
    public AttackComponent Prefab;
    public float[] Angles;

    protected void OnEnable()
    {
        foreach (var angle in Angles)
        {
            Instantiate(Prefab, transform.position, Quaternion.Euler(0, transform.parent.eulerAngles.y + angle, 0));
        }
    }
}
