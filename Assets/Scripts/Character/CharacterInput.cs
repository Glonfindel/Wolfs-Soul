using System;
using UnityEngine;

public class CharacterInput : MonoBehaviour {

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Jump { get; private set; }
    public event Action OnJump = delegate { };

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Jump = Input.GetButtonDown("Jump");
        if (Jump)
            OnJump();
    }

}
