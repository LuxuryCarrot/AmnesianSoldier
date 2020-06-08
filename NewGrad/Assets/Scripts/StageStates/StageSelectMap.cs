using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//맵을 고르는 상태.
public class StageSelectMap : StageParent
{
    public override void BeginState()
    {
        base.BeginState();
        PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
        manager.mapCanvas.SetActive(true);
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
