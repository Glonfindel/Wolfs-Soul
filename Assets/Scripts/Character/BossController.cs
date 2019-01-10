using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossController : EnemyController
{
    public List<string> AttackSequence;

    public override void SetAttack()
    {
        CurrentAttackName = AttackSequence[0];
        AttackSequence.RemoveAt(0);
        AttackSequence.Add(CurrentAttackName);
    }
}
