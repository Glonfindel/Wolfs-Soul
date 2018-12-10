using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{

    private float maxHealth = 100;
    private float health;
    public event Action OnDie = delegate { };
    public event Action OnDamageTaken = delegate { };
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
        if (health <= 0) OnDie();
    }

}
