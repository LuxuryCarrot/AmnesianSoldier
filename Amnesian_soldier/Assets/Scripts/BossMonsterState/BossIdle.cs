using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : BossParent
{
    float temp;
    float randSeed;
    public override void BeginState()
    {
        base.BeginState();
        temp = 2.0f;
        randSeed = Random.Range(0, 14);
    }
    private void Update()
    {
        if(MonsterManager.Monsters.Count==0)
           temp -= Time.deltaTime;
        if(temp<=0)
        {
            
            Debug.Log(randSeed);

            if(randSeed<=2)
            {
                manager.SetState(BossState.CHAINATTACK);

            }
            else if(randSeed>2&& randSeed <=4)
            {
                manager.SetState(BossState.MONSTERSPAWN);
            }
            else if(randSeed>4 && randSeed <= 7)
            {
                manager.SetState(BossState.TRAPATTACK);
            }
            else
                manager.SetState(BossState.ATTACK);

        }
    }
}
