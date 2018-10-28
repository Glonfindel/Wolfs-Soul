using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterController : Controller
{
    public bool IsGrounded { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public CharacterInput Input { get; private set; }
    public Health Health { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Rigidbody = GetComponent<Rigidbody>();
        Input = GetComponent<CharacterInput>();
        Health = GetComponent<Health>();
        Health.OnDie += HandleDeath;
    }

    private void OnDestroy()
    {
        Health.OnDie -= HandleDeath;
    }

    private void Update()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, 0.05f);
    }

    private void HandleDeath()
    {
        Input.enabled = false;
    }
}
