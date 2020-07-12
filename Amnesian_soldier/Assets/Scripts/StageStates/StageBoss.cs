using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBoss : StageParent
{
    public override void BeginState()
    {
        base.BeginState();
        PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
