using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifestealAttackComponent : AttackComponent
{
    public float addHealth = 5;
    private Health health;

    private void Start()
    {
        health = GetComponentInParent<Health>();
    }

    protected override void Damage(IDamageable damageable)
    {
        base.Damage(damageable);
        health.Heal(addHealth);
    }
}
