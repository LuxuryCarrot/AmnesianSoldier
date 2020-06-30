using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : CamParent
{
    int shakeTemp;
    Vector3 shakePos = new Vector3(0.2f, 0.2f, 0);
    public override void BeginState()
    {
        base.BeginState();
        shakeTemp = 12;
        Camera.main.transform.localPosition = PlayerManager.playerSingleton.camPos + new Vector3(0.5f, 0.5f,0);
    }
    private void Update()
    {
        shakeTemp--;
        if(shakeTemp <=8 && Camera.main.transform.parent!=null)

          Camera.main.transform.localPosition = PlayerManager.playerSingleton.camPos + shakePos;

        if (shakeTemp % 4 % 2 == 0)
            shakePos.x *= -1;
        else
            shakePos.y *= -1;
        if (shakeTemp <= 0)
            manager.SetState(CamState.IDLE);
    }
    public override void EndState()
    {
        base.EndState();
    }
}
