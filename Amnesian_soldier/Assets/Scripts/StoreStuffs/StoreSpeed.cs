using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSpeed : StoreParent
{
    public float speed;

    public override void Execute()
    {
        if (StageManager.stageSingletom.KillCount < 15)
            return;

        StageManager.stageSingletom.KillCount -= 15;
        PlayerManager.playerSingleton.speed *= speed;
        base.Execute();
    }
}
