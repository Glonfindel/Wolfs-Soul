using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingTrap : Trap
{

    public float startTime;
    public float interval;
    private Animator anim;
    private Collider col;

    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
        InvokeRepeating("Activate", startTime, interval);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health)
        {
            health.TakeDamage(damage);
        }
    }
    private void Update()
    {
        col.enabled = anim.GetFloat("On") == 1;
    }

    public override void Activate()
    {
        anim.SetTrigger("Trigger");
    }
}
