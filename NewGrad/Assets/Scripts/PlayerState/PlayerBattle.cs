using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//전투 결과로 상태를 판정하는 코드
public class PlayerBattle : PlayerParent
{
    
    public override void BeginState()
    {
        base.BeginState();
        //StageManager.stageSingletom.aimCanvas.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        Queue<AttackType> playertype=new Queue<AttackType>();
        for (; manager.attackType.Count != 0;)
            playertype.Enqueue(manager.attackType.Dequeue());
        
        for (int i = 0; i < manager.inputSlot.transform.childCount; i++)
            manager.inputSlot.transform.GetChild(i).GetComponent<CardParent>().DestroyThis();

        //0 이김 1 짐 2 비김 3 가드
        int win = 0;

        //지고나서 지나가는 판정일 경우.
        if(manager.losed)
        {
            manager.iteratingEnemy = null;
            manager.attackType.Clear();
            manager.SetState(PlayerState.ABANDON);
            return;
        }

        AttackType playerAnimType=AttackType.GUARD;

        if (playertype.Count < manager.iteratingEnemy.attackType.Length)
            win = 1;
        else
        {
            for(int i=0; i< manager.iteratingEnemy.attackType.Length;i++)
            {
                if (win == 3)
                {
                    playerAnimType = AttackType.GUARD;
                    break;
                }
                else
                {
                    AttackType playerType = playertype.Dequeue();
                    if (BattleDetermine.Determine(playerType, manager.iteratingEnemy.attackType[i]) == BattleResult.GUARD)
                        win = 3;
                    else if (BattleDetermine.Determine(playerType, manager.iteratingEnemy.attackType[i]) == BattleResult.WIN)
                    {
                        playerAnimType = playerType;
                        win = 0;
                    }
                    else if (BattleDetermine.Determine(playerType, manager.iteratingEnemy.attackType[i]) == BattleResult.DRAW)
                        win = 2;

                }
            }
               
        }

        manager.anim.SetInteger("AttackType", (int)playerAnimType);

        

        if (win==0)
        {
            //Time.timeScale = 0.2f;
            MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
            StageManager.stageSingletom.WinFlashCanvas.SetActive(true);
            
            manager.iteratingEnemy.SetState(EnemyState.DIE);
            manager.iteratingEnemy.enabled = false;
            
            manager.iteratingEnemy.GetComponent<CharacterController>().enabled = false;
            
            manager.iteratingEnemy = null;
            manager.attackType.Clear();

            manager.anim.SetBool("Success", true);
            manager.SetState(PlayerState.IDLE);
        }
        else if(win==1)
        {
            if (manager.iteratingEnemy.anim != null)
                manager.iteratingEnemy.anim.SetInteger("AttackType", 5);
            manager.iteratingEnemy = null;
            StageManager.stageSingletom.LoseFlashCanvas.SetActive(true);
            manager.HP--;
            StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange(-1);
            manager.attackType.Clear();
            manager.anim.SetBool("Damaged", true);
            manager.SetState(PlayerState.ABANDON);
        }
        else if(win==2)
        {
            manager.iteratingEnemy.SetState(EnemyState.KNOCKBACK);
            StageManager.stageSingletom.LoseFlashCanvas.SetActive(true);
            //manager.iteratingEnemy = null;
            //manager.HP--;
            //StageManager.stageSingletom.HPText.text = manager.HP.ToString();
            //manager.losed = true;
            manager.attackType.Clear();
            // manager.anim.SetInteger("AttackType", 0);
            manager.anim.SetBool("Success", true);
            manager.SetState(PlayerState.KNOCKBACK);
            //MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
            //StageManager.stageSingletom.WinFlashCanvas.SetActive(true);

            //manager.timeScale += 0.1f;
            //Time.timeScale = manager.timeScale;
            //manager.iteratingEnemy.SetState(EnemyState.DIE);
            //manager.iteratingEnemy.enabled = false;

            //manager.iteratingEnemy.GetComponent<CharacterController>().enabled = false;

            //manager.iteratingEnemy = null;
            //manager.attackType.Clear();

            //manager.anim.SetBool("Success", true);
            //manager.SetState(PlayerState.IDLE);
        }
        else
        {
            if (manager.iteratingEnemy.anim != null)
                manager.iteratingEnemy.anim.SetInteger("AttackType", 5);
            manager.iteratingEnemy = null;
            StageManager.stageSingletom.LoseFlashCanvas.SetActive(true);
            manager.attackType.Clear();
            //manager.anim.SetInteger("AttackType", 0);
            manager.anim.SetBool("Success", true);
            manager.SetState(PlayerState.ABANDON);
            //manager.timeScale = 1;
            //Time.timeScale = 1.0f;
        }
    }
    public override void EndState()
    {
        base.EndState();
        
    }
}
