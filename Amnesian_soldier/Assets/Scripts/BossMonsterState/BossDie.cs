using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDie : BossParent
{
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.SetTrigger("Die");
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
