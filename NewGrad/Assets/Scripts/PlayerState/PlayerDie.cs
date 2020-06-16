using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 오버 상태의 코드
public class PlayerDie : PlayerParent
{
    public override void BeginState()
    {
        base.BeginState();
        StageManager.stageSingletom.SetState(StageState.GAMEOVER);
        manager.anim.SetTrigger("Die");
        
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
