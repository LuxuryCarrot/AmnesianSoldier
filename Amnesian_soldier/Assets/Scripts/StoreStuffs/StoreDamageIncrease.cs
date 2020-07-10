using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDamageIncrease : StoreParent
{
    public float increase;
    public override void Execute()
    {
        if (StageManager.stageSingletom.KillCount < 10)
            return;

        StageManager.stageSingletom.KillCount -= 10;
        PlayerManager.playerSingleton.damage += increase;
        base.Execute();
    }
}
