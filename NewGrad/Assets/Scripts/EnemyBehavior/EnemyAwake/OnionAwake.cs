using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionAwake : EnemyAwakeParent
{
    public override void Execute()
    {
        base.Execute();
        manager.anim.SetTrigger("Appear");
    }
}
