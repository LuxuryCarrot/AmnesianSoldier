using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWake : BossParent
{
    float Pos;
    public override void BeginState()
    {
        base.BeginState();
        Pos = 4.0f;
    }
    private void Update()
    {
        Pos += Time.deltaTime * 6.0f;
        transform.position
            = new Vector3(PlayerManager.playerSingleton.transform.position.x + Pos, 3.5f, 0);

        if (Pos >= 10)
            manager.SetState(BossState.IDLE);
    }
    public override void EndState()
    {
        base.EndState();
    }
}
