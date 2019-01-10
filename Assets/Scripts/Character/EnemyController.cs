using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : Controller, ITrigger
{
    public float lookRadius = 10f;
    public NavMeshAgent AI { get; private set; }
    public Canvas UI { get; private set; }
    public BoxCollider Collider { get; private set; }
    [NonSerialized] public string CurrentAttackName;
    public GameObject GameObject
    {
        get { return gameObject; }
    }
    public ITrigger Parent { get; set; }

    protected override void Awake()
    {
        AI = GetComponent<NavMeshAgent>();
        UI = GetComponentInChildren<Canvas>();
        Collider = GetComponent<BoxCollider>();
        base.Awake();
        Health.OnDamageTaken += CheckHP;
        SetAttack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void CheckHP()
    {
        if (Parent != null && Check(gameObject))
        {
            Parent.OnTrigger(gameObject);
        }
    }

    public bool Check(GameObject go)
    {
        return Health.HealthAsPercentage <= 0;
    }

    public void OnTrigger(GameObject go)
    {
        if (Parent != null && Parent.Check(gameObject))
        {
            Parent.OnTrigger(gameObject);
        }
    }

    public virtual void SetAttack()
    {
        CurrentAttackName = Attacks.Keys.ToList()[Random.Range(0, Attacks.Count)];
    }

    protected override void GetHit()
    {
        lookRadius = float.PositiveInfinity;
        base.GetHit();
    }
}
