﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHPGain : StoreParent
{
    public int gainAmount;

    public override void Execute()
    {
        StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPMAXIncrease(gainAmount);


        PlayerManager.playerSingleton.HP += gainAmount;
        base.Execute();
    }
}