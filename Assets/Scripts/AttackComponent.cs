using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public float damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            other.GetComponent<IDamageable>().TakeDamage(damage);
        }
        catch
        {
            Debug.Log("Target is not an enemy.");
        }
    }
}
