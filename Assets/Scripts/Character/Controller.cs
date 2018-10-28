using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public CharacterData Data;
    public Dictionary<string, AttackComponent> Attacks = new Dictionary<string, AttackComponent>();
    
    protected virtual void Awake()
    {
        Attacks = GetComponentsInChildren<AttackComponent>().ToDictionary(e => e.name);
        SetAllAttacksActive(false);
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
