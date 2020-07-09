using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArchorAwake : EnemyInstantiateParent
{
    public override void Execute()
    {
        base.Execute();
        manager.attackType = AttackType.NONE;
        manager.SetAttackImage();
    }
}
