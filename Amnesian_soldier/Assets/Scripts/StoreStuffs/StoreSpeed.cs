using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSpeed : StoreParent
{
    public float speed;

    public override void Execute()
    {
        PlayerManager.playerSingleton.speed *= speed;
        base.Execute();
    }
}
