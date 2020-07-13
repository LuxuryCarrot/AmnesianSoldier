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
                manager.HP-=manager.iteratingEnemy.damage;
                manager.speed *= 0.95f;
                manager.anim.SetBool("Damaged", true);
                if (manager.iteratingEnemy.battleBehavior != null)
                    manager.iteratingEnemy.battleBehavior.Execute();
                StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange();
                manager.SetState(PlayerState.KNOCKBACK);
                //적 공격 애니메이션 추가부분
            }
            else if(manager.iteratingEnemy.attackType == AttackType.HORIZON)
            {
                MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
                StageManager.stageSingletom.WinFlashCanvas.SetActive(true);
                manager.attackType = AttackType.NONE;
                manager.anim.SetBool("Success", true);
                manager.iteratingEnemy.hp -= manager.weapon.weaponDamage;
                if (manager.iteratingEnemy.damageBehavior != null)
                    manager.iteratingEnemy.damageBehavior.Execute();
                if (manager.iteratingEnemy.hp > 0)
                {
                    manager.HP -= manager.iteratingEnemy.damage;
                    StageManager.stageSingletom.HitKillSpawn(manager.iteratingEnemy.transform.position, true);
                    manager.speed *= 0.95f;
                    manager.anim.SetBool("Damaged", true);
                    if (manager.iteratingEnemy.battleBehavior != null)
                        manager.iteratingEnemy.battleBehavior.Execute();
                    //if (manager.iteratingEnemy.anim != null)
                    //    manager.iteratingEnemy.anim.SetTrigger("Attack");
                    manager.iteratingEnemy.attackType = AttackType.NONE;
                    manager.iteratingEnemy.SetAttackImage();
                    StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange();
                    manager.SetState(PlayerState.KNOCKBACK);
                }
                else
                {
                    manager.iteratingEnemy = null;
                    
                    manager.SetState(PlayerState.IDLE);
                }
                //체력 2이상 몬스터 수정요망
            }
            else
            {
                MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
                StageManager.stageSingletom.WinFlashCanvas.SetActive(true);
                manager.attackType = AttackType.NONE;
                manager.anim.SetBool("Success", true);
                manager.iteratingEnemy.SetState(EnemyState.KNOCKBACK);
                StageManager.stageSingletom.HitKillSpawn(manager.iteratingEnemy.transform.position, true);
                manager.iteratingEnemy.hp -= manager.weapon.weaponDamage;
                if (manager.iteratingEnemy.damageBehavior != null)
                    manager.iteratingEnemy.damageBehavior.Execute();
                manager.iteratingEnemy = null;
                manager.SetState(PlayerState.IDLE);
            }
            
        }
        else if(manager.attackType == AttackType.GUARD)
        {
            if (manager.iteratingEnemy.attackType == AttackType.GUARD)
            {
                //manager.anim.SetTrigger("GuardAttack");
                manager.anim.SetBool("Charging", true);
                manager.iteratingEnemy.attackType = AttackType.NONE;
                manager.iteratingEnemy.SetAttackImage();

                manager.SetState(PlayerState.PINN);
            }
            else if(manager.iteratingEnemy.attackType == AttackType.HORIZON)
            {
                manager.anim.SetTrigger("GuardAttack");
                manager.iteratingEnemy.attackType = AttackType.NONE;
                manager.iteratingEnemy.SetAttackImage();
                manager.iteratingEnemy.SetState(EnemyState.KNOCKBACK);
                manager.iteratingEnemy = null;
                manager.SetState(PlayerState.IDLE);
            }
            else
            {
                manager.iteratingEnemy = null;
                manager.SetState(PlayerState.ABANDON);
            }
        }
        else
        {
            if (manager.iteratingEnemy.attackType == AttackType.NONE)
            {
                manager.iteratingEnemy = null;
                manager.SetState(PlayerState.ABANDON);
            }
            else
            {
                //if(manager.iteratingEnemy.attackType == AttackType.HORIZON)
                //    if (manager.iteratingEnemy.anim != null)
                //        manager.iteratingEnemy.anim.SetTrigger("Attack");
                manager.HP -= manager.iteratingEnemy.damage;
                manager.speed *= 0.95f;
                manager.anim.SetBool("Damaged", true);
                StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange();
                manager.SetState(PlayerState.KNOCKBACK);
                //적 공격 애니메이션 추가부분
            }
        }
        if(manager.iteratingEnemy!=null)
           manager.iteratingEnemy.isStuned = true;
    }
    public override void EndState()
    {
        base.EndState();
        
    }
}
