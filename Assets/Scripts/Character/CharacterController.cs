using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterController : Controller
{
    public static CharacterController Player;
    public Rigidbody Rigidbody { get; private set; }
    public CharacterInput Input { get; private set; }
    public Energy Energy { get; private set; }
    public Dictionary<string, Animator> Forms = new Dictionary<string, Animator>();
    public StateMachineAsset WerewolfData;

    protected override void Awake()
    {
        Player = this;
        base.Awake();
        Rigidbody = GetComponent<Rigidbody>();
        Input = GetComponent<CharacterInput>();
        Energy = GetComponent<Energy>();
        Forms = GetComponentsInChildren<Animator>().ToDictionary(e => e.name);
        Transform(false);
    }

    public void Transform(bool active)
    {
        Forms["Wolf"].gameObject.SetActive(!active);
        Forms["Werewolf"].gameObject.SetActive(active);
        stateMachine = active ? WerewolfData.Create(gameObject) : Data.Create(gameObject);
    }

}
