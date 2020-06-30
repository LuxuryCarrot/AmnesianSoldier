using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamIdel : CamParent
{
    public override void BeginState()
    {
        base.BeginState();
        if(Camera.main.transform.parent!=null)
           transform.localPosition = PlayerManager.playerSingleton.camPos;
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
