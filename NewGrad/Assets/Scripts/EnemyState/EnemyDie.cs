using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : EnemyParent
{
    public override void BeginState()
    {
        base.BeginState();
        if (manager.dieBehavior != null)
            manager.dieBehavior.Begin();

        if (manager.anim != null)
            manager.anim.SetBool("Die", true);
    }
    private void Update()
    {
        if(manager.dieBehavior!=null)
            manager.dieBehavior.Execute();
    }
    public override void EndState()
    {
        base.EndState();
    }
}
