﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDie : EnemyDieParent
{
    public int Level;
    public Vector3 FlySpeed;
    public float Gravity;
    float temp;

    private void Awake()
    {
        FlySpeed = new Vector3(10, 20, 0);
        Gravity = 10;
        manager = GetComponent<EnemyManager>();
        if (Level == 0)
            Level = 2;
    }
    public override void Begin()
    {
        base.Begin();
        if (Level > 1)
        {
            manager.anim.SetTrigger("Devide");
            SlimeSpawn();
            manager.enabled = false;
        }
        else
            manager.anim.SetBool("Die", true);

        temp = 0.2f;
    }
    public override void Execute()
    {
        base.Execute();
        if (temp >= 0)
        {
            temp -= Time.deltaTime;
            return;
        }
        if(Level>1)
        {
            transform.position += FlySpeed * Time.deltaTime;
            FlySpeed -= new Vector3(0, Gravity * Time.deltaTime, 0);
        }
    }
    public void SlimeSpawn()
    {
        Vector3 SpawnSpot1 = Vector3.zero;
        Vector3 SpawnSpot2 = Vector3.zero;

        for(int i=0; i<MonsterManager.Monsters.Count; i++)
        {
            if (MonsterManager.Monsters[i].transform.position.x <= PlayerManager.playerSingleton.transform.position.x)
                return;

            if (SpawnSpot2 != Vector3.zero)
                break;

            float findXPos = MonsterManager.Monsters[i].transform.position.x + 12;
            bool findMonster=false;
            for (int j=0; j<MonsterManager.Monsters.Count; j++)
            {
                if(Mathf.Abs(MonsterManager.Monsters[j].transform.position.x -findXPos)<=5)
                {
                    findMonster = true;
                    break;
                }
            }

            if(MonsterManager.Monsters[i].transform.position.x>=this.transform.position.x+12
                &&!findMonster)
            {
                Vector3 spawn = MonsterManager.Monsters[i].transform.position + new Vector3(12, 0, 0);
                if (spawn.x >= MapPositionManager.mapMax)
                    break;
                else if (SpawnSpot1 == Vector3.zero)
                    SpawnSpot1 = spawn;
                else
                    SpawnSpot2 = spawn;
            }
            
        }

        if(SpawnSpot1!=Vector3.zero)
        {
            GameObject monster = Instantiate(Resources.Load("Prefabs/Monsters/SlimeSmall") as GameObject, MapPositionManager.field.transform.GetChild(0));
            monster.GetComponent<SlimeDie>().Level = Level - 1;
            monster.transform.localPosition = SpawnSpot1;
            
            MonsterManager.Monsters.Add(monster);
        }

        if(SpawnSpot2!=Vector3.zero)
        {
            GameObject monster = Instantiate(Resources.Load("Prefabs/Monsters/SlimeSmall") as GameObject, MapPositionManager.field.transform.GetChild(0));
            monster.GetComponent<SlimeDie>().Level = Level - 1;
            monster.transform.localPosition = SpawnSpot2;
            Debug.Log("Spawn");
            MonsterManager.Monsters.Add(monster);
        }
    }
}