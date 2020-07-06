using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어가 대기중인 상태.
public class PlayerDelay : PlayerParent
{
    public override void BeginState()
    {
        base.BeginState();
        
        if(manager.anim!=null)
           manager.anim.SetBool("Ready",true);
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
