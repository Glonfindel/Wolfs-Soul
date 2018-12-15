using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAICondition : Condition
{
    private string attackName;

    public AttackAICondition(string attackName)
    {
        this.attackName = attackName;
    }

    public override bool Check(GameObject target)
    {
        return CharacterController.Player.Health.HealthAsPercentage > 0 && target.GetComponent<EnemyController>().CurrentAttackName == attackName;
    }
}
