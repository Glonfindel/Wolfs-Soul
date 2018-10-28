using System;
using UnityEngine;

public class CharacterInput : MonoBehaviour {

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Jump { get; private set; }
    public bool MeleeAttack { get; private set; }
    public event Action OnMeleeAttack = delegate { };
    public bool RangeAttack { get; private set; }
    public event Action OnRangeAttack = delegate { };
    public bool Transformation { get; private set; }
    public event Action OnTransformation = delegate { };

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        Jump = Input.GetButtonDown("Jump");
        MeleeAttack = Input.GetButtonDown("MeleeAttack");
        RangeAttack = Input.GetButtonDown("RangeAttack");
        Transformation = Input.GetButtonDown("Transformation");

        if (MeleeAttack)
            OnMeleeAttack();
        if (RangeAttack)
            OnRangeAttack();
        if (Transformation)
            OnTransformation();
    }

}
