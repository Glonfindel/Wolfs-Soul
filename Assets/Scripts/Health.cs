using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{

    [SerializeField] private int maxHealth = 100;
    private int health;
    public event Action OnDie = delegate { };

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0) return;

        health -= damage;
        if (health <= 0)
            OnDie();
    }

}
