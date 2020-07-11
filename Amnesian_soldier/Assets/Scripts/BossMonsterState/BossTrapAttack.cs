using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrapAttack : BossParent
{
    float trapTemp;
    int traCount;
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.SetTrigger("TrapAttack");
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
