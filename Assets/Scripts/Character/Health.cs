using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public float CurrentHealth
    {
        get
        {
            return health;
        }
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            OnHealed();
        }
    }

    [SerializeField] private float maxHealth = 100;
    private float health;
    public event Action OnDamageTaken = delegate { };
    public event Action OnHealed = delegate { };
    public float HealthAsPercentage { get { return health / maxHealth; } }

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (health <= 0) return;

        health -= damage;
        
        OnDamageTaken();
    }

    public void Heal(float value)
    {
        health = Mathf.Clamp(health += value, 0, maxHealth);
        OnHealed();
    }

}
