using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    private int health;

    private void Awake()
    {
        health = maxHealth;
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    private void Die()
    {

    }
}
