using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAwake : BossParent
{
    float Pos;
    float temp;
    float gravity;
    public override void BeginState()
    {
        base.BeginState();
        transform.position
            = new Vector3(PlayerManager.playerSingleton.transform.position.x + 10, 20.0f, 0);
        manager.anim.SetTrigger("Summon");
    }
    private void Update()
    {
        if(Pos<=6.5f)
          Pos += Time.deltaTime * 26f;
        else
        {
            if (CameraManager.camSingleTon.current != CamState.HARDSHAKE)
                CameraManager.camSingleTon.SetState(CamState.HARDSHAKE);
            temp += Time.deltaTime;
        }

        transform.position
            = new Vector3(PlayerManager.playerSingleton.transform.position.x + 10, 10-Pos, 0);

        if (temp >= 0.5f)
            manager.SetState(BossState.IDLE);
    }
    public override void EndState()
    {
        base.EndState();
    }
}
