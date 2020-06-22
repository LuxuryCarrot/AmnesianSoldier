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
        //Time.timeScale = 1.0f;
        
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

        //AttackType playerAnimType=AttackType.GUARD;

        if (playertype.Count == 0)
            win = 1;
        else
        {
            AttackType temp = playertype.Dequeue();
            if (BattleDetermine.Determine(temp, manager.iteratingEnemy.attackType[manager.iteratingEnemy.eliteBattleTemp])
                == BattleResult.WIN)
                win = 0;
            else if (BattleDetermine.Determine(temp, manager.iteratingEnemy.attackType[manager.iteratingEnemy.eliteBattleTemp])
                == BattleResult.LOSE)
                win = 1;
            else if (BattleDetermine.Determine(temp, manager.iteratingEnemy.attackType[manager.iteratingEnemy.eliteBattleTemp])
                == BattleResult.DRAW)
                win = 2;
            else
                win = 3;

            manager.iteratingEnemy.eliteBattleTemp++;
        }

        //manager.anim.SetInteger("AttackType", (int)playerAnimType);

        

        if (win==0)
        {

            manager.iteratingEnemy.SetAttackImage();
            MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
            StageManager.stageSingletom.WinFlashCanvas.SetActive(true);
            manager.attackType.Clear();
            if(manager.timeScale >1)
            {
                manager.timeScale *= 0.995f;
            }
            manager.anim.SetBool("Success", true);

            if (manager.iteratingEnemy.eliteBattleTemp == manager.iteratingEnemy.attackType.Length)
            {
                Time.timeScale = 0.3f;
                //Camera.main.fieldOfView = manager.minCamScale;
                manager.iteratingEnemy.SetState(EnemyState.DIE);
                manager.iteratingEnemy.enabled = false;

                manager.iteratingEnemy.GetComponent<CharacterController>().enabled = false;

                manager.iteratingEnemy = null;
                manager.SetState(PlayerState.IDLE);
            }
            else
            {
                manager.SetState(PlayerState.NEXTBATTLE);
            }
            
            
        }
        else if(win==1)
        {
            manager.timeScale *= 1.01f;
            Time.timeScale = manager.timeScale;
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
            //manager.iteratingEnemy.SetState(EnemyState.KNOCKBACK);
            //StageManager.stageSingletom.LoseFlashCanvas.SetActive(true);
            ////manager.iteratingEnemy = null;
            ////manager.HP--;
            ////StageManager.stageSingletom.HPText.text = manager.HP.ToString();
            ////manager.losed = true;
            //manager.attackType.Clear();
            //// manager.anim.SetInteger("AttackType", 0);
            //manager.anim.SetBool("Success", true);
            //manager.SetState(PlayerState.KNOCKBACK);
            //MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
            //StageManager.stageSingletom.WinFlashCanvas.SetActive(true);
            manager.iteratingEnemy.SetAttackImage();
            manager.timeScale *= 1.01f;
            Time.timeScale = manager.timeScale;
            manager.anim.SetBool("Success", true);
            manager.SetState(PlayerState.IDLE);

            if (manager.iteratingEnemy.eliteBattleTemp == manager.iteratingEnemy.attackType.Length)
            {
                manager.iteratingEnemy.SetState(EnemyState.DIE);
                manager.iteratingEnemy.enabled = false;

                manager.iteratingEnemy.GetComponent<CharacterController>().enabled = false;

                manager.iteratingEnemy = null;
                manager.attackType.Clear();
            }
            else
            {
                manager.SetState(PlayerState.NEXTBATTLE);
            }
            
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
            manager.timeScale = 1;
            Time.timeScale = 1.0f;
        }
    }
    public override void EndState()
    {
        base.EndState();
        
    }
}
