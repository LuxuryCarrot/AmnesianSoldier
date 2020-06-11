using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//전투 결과로 상태를 판정하는 코드
public class PlayerBattle : PlayerParent
{
    
    public override void BeginState()
    {
        base.BeginState();
    }
    private void Update()
    {
        Queue<AttackType> playertype=new Queue<AttackType>();
        for (; manager.attackType.Count != 0;)
            playertype.Enqueue(manager.attackType.Dequeue());
        
        for (int i = 0; i < manager.inputSlot.transform.childCount; i++)
            manager.inputSlot.transform.GetChild(i).GetComponent<CardParent>().DestroyThis();

        //0 이김 1 짐 2 비김 3 카드수 부족
        int win = 0;

        if(manager.losed)
        {
            manager.iteratingEnemy = null;
            manager.attackType.Clear();
            manager.SetState(PlayerState.ABANDON);
            return;
        }

        if (playertype.Count < manager.iteratingEnemy.attackType.Length)
            win = 3;
        else
        {
            for(int i=0; i< manager.iteratingEnemy.attackType.Length;i++)
            {
                if (win == 1)
                    break;
                else
                {
                    AttackType playerType =playertype.Dequeue();
                    if (BattleDetermine.Determine(playerType, manager.iteratingEnemy.attackType[i]) == BattleResult.LOSE)
                        win = 1;
                    else if (BattleDetermine.Determine(playerType, manager.iteratingEnemy.attackType[i]) == BattleResult.WIN)
                        win = 0;
                    else
                        win = 2;
                }
            }
               
        }

        if(manager.iteratingEnemy.anim!=null)
           manager.iteratingEnemy.anim.SetInteger("AttackType", (int)manager.iteratingEnemy.attackType[0]);
        if (win==0)
        {
            MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
            StageManager.stageSingletom.WinFlashCanvas.SetActive(true);
            //if (manager.iteratingEnemy.anim != null && manager.iteratingEnemy.dieBehavior == null)
            //    manager.iteratingEnemy.anim.SetBool("Die", true);
            //else if (manager.iteratingEnemy.dieBehavior != null)
            //{
                manager.iteratingEnemy.SetState(EnemyState.DIE);
                manager.iteratingEnemy.enabled = false;
            //}
            manager.iteratingEnemy.GetComponent<CharacterController>().enabled = false;
            
            manager.iteratingEnemy = null;
            manager.attackType.Clear();
            manager.SetState(PlayerState.IDLE);
        }
        else if(win==3)
        {
            if (manager.iteratingEnemy.anim != null)
                manager.iteratingEnemy.anim.SetInteger("AttackType", 5);
            manager.iteratingEnemy = null;
            StageManager.stageSingletom.LoseFlashCanvas.SetActive(true);
            manager.HP--;
            StageManager.stageSingletom.HPText.text = manager.HP.ToString();
            manager.attackType.Clear();
            manager.SetState(PlayerState.ABANDON);
        }
        else if(win==1)
        {
            manager.iteratingEnemy.SetState(EnemyState.KNOCKBACK);
            StageManager.stageSingletom.LoseFlashCanvas.SetActive(true);
            //manager.iteratingEnemy = null;
            manager.HP--;
            StageManager.stageSingletom.HPText.text = manager.HP.ToString();
            manager.losed = true;
            manager.attackType.Clear();
            manager.SetState(PlayerState.KNOCKBACK);
        }
        else
        {
            manager.iteratingEnemy.SetState(EnemyState.KNOCKBACK);
            StageManager.stageSingletom.DrawFlashCanvas.SetActive(true);
            //manager.iteratingEnemy = null;
            manager.attackType.Clear();
            manager.SetState(PlayerState.KNOCKBACK);
        }
    }
    public override void EndState()
    {
        base.EndState();
        
    }
}
