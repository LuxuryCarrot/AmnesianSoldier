using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnMob : BossParent
{
    float temp;
    public int spawnAmount;
    int spawn;
    public override void BeginState()
    {
        base.BeginState();
        temp = 2;
        spawn = spawnAmount;
    }
    private void Update()
    {
        temp -= Time.deltaTime;
        if(temp <=0)
        {
            GameObject newMob = Instantiate(manager.MonsterSpawnPool[Random.Range(0, manager.MonsterSpawnPool.Length)]);
            newMob.transform.position = transform.position - new Vector3(0.5f, 0, 0);
            MonsterManager.Monsters.Add(newMob);
            spawn--;
            temp = 2;
            if (spawn <= 0)
                manager.SetState(BossState.IDLE);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
