using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Health))]
public class Controller : MonoBehaviour
{
    public StateMachineAsset Data;
    public Dictionary<string, CombatComponent> Attacks = new Dictionary<string, CombatComponent>();
    public Health Health { get; private set; }
    protected IStateMachine stateMachine;

    protected virtual void Awake()
    {
        Attacks = GetComponentsInChildren<CombatComponent>().ToDictionary(e => e.name);
        Health = GetComponent<Health>();
        stateMachine = Data.Create(gameObject);
        Health.OnDamageTaken += GetHit;
    }

    private void Start()
    {
        SetAllAttacksActive(false);
    }

    private void OnDestroy()
    {
        Health.OnDamageTaken -= GetHit;
    }

    protected virtual void Update()
    {
        stateMachine.Update(Time.deltaTime);
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

    protected virtual void GetHit()
    {
        if (Random.Range(0, 100) < 30 || Health.HealthAsPercentage <= 0)
            stateMachine.ChangeState("GetHit");
    }
}
