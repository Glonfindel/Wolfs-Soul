using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Controller : MonoBehaviour
{
    public StateMachineAsset Data;
    public Dictionary<string, CombatComponent> Attacks = new Dictionary<string, CombatComponent>();
    protected IStateMachine stateMachine;
    public Health Health { get; private set; }

    protected virtual void Awake()
    {
        Attacks = GetComponentsInChildren<CombatComponent>().ToDictionary(e => e.name);
        SetAllAttacksActive(false);
        Health = GetComponent<Health>();
        stateMachine = Data.Create(gameObject);
        Health.OnDamageTaken += GetHit;
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

    private void GetHit()
    {
        if (Random.Range(0, 100) < 50 || Health.HealthAsPercentage <= 0)
            stateMachine.ChangeState("GetHit");
    }
}
