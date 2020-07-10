using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossBattle : PlayerParent
{
    int answer;
    public override void BeginState()
    {
        base.BeginState();
        answer = 0;
    }
    private void Update()
    {
        manager.controller.Move(manager.speedIncrease * manager.speed * Time.deltaTime);
        if(manager.boss.attacktQueue.Count==0)
        {
            
            if (answer >= 3)
            {
                manager.boss.SetState(BossState.STUN);
                manager.boss.hp -= 5;
                manager.SetState(PlayerState.IDLE);
            }
            else
            {
                manager.boss.SetState(BossState.IDLE);
                manager.SetState(PlayerState.KNOCKBACK);
                manager.HP -= 3;
                StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange();
            }
        }
        else if(Input.GetMouseButtonDown(0))
        {
            GameObject thisButton = manager.boss.transform.GetChild(1).GetChild(0).gameObject;
            thisButton.transform.SetParent(null);
            Destroy(thisButton);
            if(manager.boss.attacktQueue.Peek()==AttackType.GUARD)
            {
                manager.boss.attacktQueue.Dequeue();
                answer++;
            }
            else
            {
                manager.boss.attacktQueue.Dequeue();
                answer--;
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            GameObject thisButton = manager.boss.transform.GetChild(1).GetChild(0).gameObject;
            thisButton.transform.SetParent(null);
            Destroy(thisButton);
            if (manager.boss.attacktQueue.Peek() == AttackType.HORIZON)
            {
                manager.boss.attacktQueue.Dequeue();
                answer++;
            }
            else
            {
                manager.boss.attacktQueue.Dequeue();
                answer--;
            }
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
