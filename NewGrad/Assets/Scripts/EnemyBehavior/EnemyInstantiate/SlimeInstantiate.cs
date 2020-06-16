using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeInstantiate : EnemyInstantiateParent
{
    public override void Execute()
    {
        base.Execute();
        manager.transform.GetChild(1).GetChild(0).position -= new Vector3(0, 0.5f, 0);
    }
}
