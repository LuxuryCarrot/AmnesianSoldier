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
        //manager.anim.SetInteger("AttackType", (int)playerAnimType);

        if (manager.attackType==AttackType.HORIZON)
        {
            if(manager.iteratingEnemy.attackType == AttackType.GUARD)
            {
                manager.HP--;
                manager.speed *= 0.95f;
                manager.anim.SetBool("Damaged", true);
                StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange(-1);
                manager.SetState(PlayerState.KNOCKBACK);
                //적 공격 애니메이션 추가부분
            }
            else if(manager.iteratingEnemy.attackType == AttackType.HORIZON)
            {
                MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
                StageManager.stageSingletom.WinFlashCanvas.SetActive(true);
                manager.attackType = AttackType.NONE;
                manager.anim.SetBool("Success", true);
                manager.iteratingEnemy.SetState(EnemyState.DIE);
                manager.iteratingEnemy.enabled = false;

                manager.iteratingEnemy.GetComponent<CharacterController>().enabled = false;

                manager.iteratingEnemy = null;
                manager.SetState(PlayerState.IDLE);

                //체력 2이상 몬스터 수정요망
            }
            else
            {
                MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
                StageManager.stageSingletom.WinFlashCanvas.SetActive(true);
                manager.attackType = AttackType.NONE;
                manager.anim.SetBool("Success", true);
                manager.iteratingEnemy.SetState(EnemyState.DIE);
                manager.iteratingEnemy.enabled = false;

                manager.iteratingEnemy.GetComponent<CharacterController>().enabled = false;

                manager.iteratingEnemy = null;
                manager.SetState(PlayerState.IDLE);
            }
            
        }
        else if(manager.attackType == AttackType.GUARD)
        {
           if(manager.iteratingEnemy.attackType == AttackType.GUARD)
            {
                manager.anim.SetTrigger("GuardAttack");
                manager.iteratingEnemy.SetState(EnemyState.KNOCKBACK);
                manager.iteratingEnemy.attackType = AttackType.NONE;
                manager.iteratingEnemy.SetAttackImage();
                manager.iteratingEnemy = null;
                manager.SetState(PlayerState.IDLE);
            }
           else
            {
                MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
                StageManager.stageSingletom.WinFlashCanvas.SetActive(true);
                manager.attackType = AttackType.NONE;
                manager.iteratingEnemy.SetState(EnemyState.DIE);
                manager.iteratingEnemy.enabled = false;

                manager.iteratingEnemy.GetComponent<CharacterController>().enabled = false;

                manager.iteratingEnemy = null;
                manager.SetState(PlayerState.IDLE);
            }
        }
        else
        {
            manager.HP--;
            manager.speed *= 0.95f;
            manager.anim.SetBool("Damaged", true);
            StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange(-1);
            manager.SetState(PlayerState.KNOCKBACK);
            //적 공격 애니메이션 추가부분

        }

    }
    public override void EndState()
    {
        base.EndState();
        
    }
}
