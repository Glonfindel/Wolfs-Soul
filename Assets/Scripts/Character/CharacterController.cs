using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterData Data;
    public Dictionary<string, AttackComponent> Attacks = new Dictionary<string, AttackComponent>();
    public bool IsGrounded { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public CharacterInput Input { get; private set; }
    private Health health;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Input = GetComponent<CharacterInput>();
        health = GetComponent<Health>();
        health.OnDie += HandleDeath;
        Attacks = GetComponentsInChildren<AttackComponent>().ToDictionary(e => e.name);
        SetAllAttacksActive(false);
    }

    private void OnDestroy()
    {
        health.OnDie -= HandleDeath;
    }

    private void Update()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, 0.05f);
    }

    private void HandleDeath()
    {
        Input.enabled = false;
    }

    public void SetAllAttacksActive(bool active = true)
    {
        foreach (var attack in Attacks.Values)
        {
            attack.gameObject.SetActive(active);
        }
    }

    public void SetAttackActive(string name, bool active = true)
    {
        Attacks[name].gameObject.SetActive(active);
    }

}
