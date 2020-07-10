using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDamaged : EnemyDamagedParent
{
    public override void Execute()
    {
        base.Execute();
        manager.SetState(EnemyState.KNOCKBACK);
        manager.GetComponent<EnemyKnockBack>().knockBackRate *= 5;
    }
}
