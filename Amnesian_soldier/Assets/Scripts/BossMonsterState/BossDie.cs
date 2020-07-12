using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDie : BossParent
{
    float temp;
    public override void BeginState()
    {
        base.BeginState();
        manager.anim.SetTrigger("Die");
        
        CameraManager.camSingleTon.SetState(CamState.HARDSHAKE);
    }
    private void Update()
    {
        if(temp==0)
            Time.timeScale = 0;
        temp += Time.fixedDeltaTime;
        if(temp>=1)
        {
            Time.timeScale = 1;
        }

        if(temp>=3)
           StageManager.stageSingletom.SetState(StageState.GAMECLEAR);
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
