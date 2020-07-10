using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHPGain : StoreParent
{
    public int gainAmount;

    public override void Execute()
    {
        if (StageManager.stageSingletom.KillCount < 15)
            return;

        StageManager.stageSingletom.KillCount -= 15;
        StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPMAXIncrease(gainAmount);


        PlayerManager.playerSingleton.HP += gainAmount;
        base.Execute();
    }
}
