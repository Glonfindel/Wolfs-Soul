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

    protected override void Damage(IDamageable damageable)
    {
        base.Damage(damageable);
        energy.CurrentEnergy += addEnergy;
    }
}
