using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrap : Trap {

    private Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}

    private void OnTriggerEnter(Collider collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health)
        {
            Activate();
            health.TakeDamage(damage);
        }
        
    }

    public override void Activate() {
        anim.SetTrigger("Trigger");
    }
}
