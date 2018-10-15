using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private float jumpPower = 5f;
    public Dictionary<string, AttackComponent> Attacks = new Dictionary<string, AttackComponent>();
    public bool IsGrounded { get; private set; }
    private Rigidbody rigidbody;
    private CharacterInput characterInput;
    private Health health;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        characterInput = GetComponent<CharacterInput>();
        health = GetComponent<Health>();
        characterInput.OnJump += HandleJump;
        health.OnDie += HandleDeath;
        Attacks = GetComponentsInChildren<AttackComponent>().ToDictionary(e => e.name);
        SetAllAttacksActive(false);
    }

    private void OnDestroy()
    {
        characterInput.OnJump -= HandleJump;
        health.OnDie -= HandleDeath;
    }

    private void Update()
    {
        transform.position += Time.deltaTime * characterInput.Vertical * transform.forward * moveSpeed;
        transform.Rotate(Vector3.up * characterInput.Horizontal * turnSpeed * Time.deltaTime);
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, 0.05f);
    }

    private void HandleJump()
    {
        if (IsGrounded)
            rigidbody.AddForce(characterInput.Vertical * transform.forward * jumpPower + Vector3.up * jumpPower, ForceMode.Impulse);
    }

    private void HandleDeath()
    {
        characterInput.enabled = false;
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
