using System;
using UnityEngine;

public class CharacterInput : MonoBehaviour {

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Jump { get; private set; }
    public bool Dodge { get; private set; }
    public bool MeleeAttack { get; private set; }
    public event Action OnMeleeAttack = delegate { };
    public bool RangeAttack { get; private set; }
    public event Action OnRangeAttack = delegate { };
    public bool Transformation { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        Jump = Input.GetButtonDown("Jump");
        Dodge = Input.GetButtonDown("Dodge");
        MeleeAttack = Input.GetButtonDown("MeleeAttack");
        RangeAttack = Input.GetButtonDown("RangeAttack");
        Transformation = Input.GetButtonDown("Transformation");
    }

}
