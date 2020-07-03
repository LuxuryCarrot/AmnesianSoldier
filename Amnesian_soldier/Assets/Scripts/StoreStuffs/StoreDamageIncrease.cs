﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDamageIncrease : StoreParent
{
    public int increase;
    public override void Execute()
    {
        
        PlayerManager.playerSingleton.damage += increase;
        base.Execute();
    }
}
