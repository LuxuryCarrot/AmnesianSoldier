using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossBattle : PlayerParent
{
    public override void BeginState()
    {
        base.BeginState();
    }
    private void Update()
    {
        manager.controller.Move(manager.speedIncrease * manager.speed * Time.deltaTime);
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
