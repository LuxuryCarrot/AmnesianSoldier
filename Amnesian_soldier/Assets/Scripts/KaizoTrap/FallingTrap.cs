using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : TrapParent
{
    public override void DetactThis()
    {
        base.DetactThis();
        
    }
    private void Update()
    {
        DetactThis();
    }
    public override void Execute()
    {
        
    }
    public override void SpaceIterat()
    {
        PlayerManager.playerSingleton.SetState(PlayerState.JUMP);
    }
    public override void Penalty()
    {
        PlayerManager.playerSingleton.gravity *= 2;
    }
}
