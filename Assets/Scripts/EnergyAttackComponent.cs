using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyAttackComponent : AttackComponent
{
    public float addEnergy = 5;
    private Energy energy;

    private void Start()
    {
        energy = GetComponentInParent<Energy>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        energy.CurrentEnergy += addEnergy;
    }
}
