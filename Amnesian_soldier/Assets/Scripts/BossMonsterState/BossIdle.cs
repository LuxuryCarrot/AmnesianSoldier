using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : BossParent
{
    float temp;
    public override void BeginState()
    {
        base.BeginState();
        temp = 3;
    }
    private void Update()
    {
        temp -= Time.deltaTime;
        if(temp<=0)
        {
            float randSeed = Random.Range(0, 0.015f);
            if(randSeed<=0.005f)
            {
                manager.SetState(BossState.CHAINATTACK);

            }
            else if(randSeed>0.01f)
            {
                manager.SetState(BossState.MONSTERSPAWN);
            }
            else
            {
                manager.SetState(BossState.TRAPATTACK);
            }
        }
    }
}
