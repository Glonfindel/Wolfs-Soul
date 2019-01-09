using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAICondition : ICondition
{
    private string attackName;

    public AttackAICondition(string attackName)
    {
        this.attackName = attackName;
    }

    public bool Check(GameObject target)
    {
        return CharacterController.Player.Health.HealthAsPercentage > 0 && target.GetComponent<EnemyController>().CurrentAttackName == attackName;
    }
}
