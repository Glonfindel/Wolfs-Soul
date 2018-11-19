using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterController : Controller
{
    public Rigidbody Rigidbody { get; private set; }
    public CharacterInput Input { get; private set; }
    public Energy Energy { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Rigidbody = GetComponent<Rigidbody>();
        Input = GetComponent<CharacterInput>();
        Energy = GetComponent<Energy>();
    }

}
