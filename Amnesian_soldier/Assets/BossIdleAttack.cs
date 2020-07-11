using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleAttack : BossParent
{
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.SetTrigger("Attack");
    }
    private void Update()
    {
        

    }
    public override void EndState()
    {
        base.EndState();
    }
}
