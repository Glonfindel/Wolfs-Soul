using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public float damage = 5;

    void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Damage(damageable);
        }
    }

    protected virtual void Damage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }
}
