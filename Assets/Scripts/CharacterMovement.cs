using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private float jumpPower = 5f;

    private Rigidbody rigidbody;
    private CharacterInput characterInput;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        characterInput = GetComponent<CharacterInput>();
        characterInput.OnJump += HandleJump;
    }

    private void OnDestroy()
    {
        characterInput.OnJump -= HandleJump;
    }

    private void Update()
    {
        transform.position += Time.deltaTime * characterInput.Vertical * transform.forward * moveSpeed;
        transform.Rotate(Vector3.up * characterInput.Horizontal * turnSpeed * Time.deltaTime);
    }

    private void HandleJump()
    {
        rigidbody.AddForce(characterInput.Vertical * transform.forward * jumpPower + Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
