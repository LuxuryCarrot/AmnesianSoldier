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
        if(BattleDetermine.Determine(manager.attackType, manager.iteratingEnemy.attackType) ==BattleResult.WIN)
        {
            MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
            Destroy(manager.iteratingEnemy.gameObject);
            manager.iteratingEnemy = null;
            manager.attackType = AttackType.NONE;
            manager.SetState(PlayerState.IDLE);
        }
        else if(manager.attackType==AttackType.NONE)
        {
            manager.iteratingEnemy = null;
            manager.attackType = AttackType.NONE;
            manager.SetState(PlayerState.ABANDON);
        }
        else if(BattleDetermine.Determine(manager.attackType, manager.iteratingEnemy.attackType) == BattleResult.LOSE)
        {
            manager.iteratingEnemy.SetState(EnemyState.KNOCKBACK);
            manager.iteratingEnemy = null;
            manager.HP--;
            manager.attackType = AttackType.NONE;
            manager.SetState(PlayerState.KNOCKBACK);
        }
        else
        {
            manager.iteratingEnemy.SetState(EnemyState.KNOCKBACK);
            manager.iteratingEnemy = null;
            manager.attackType = AttackType.NONE;
            manager.SetState(PlayerState.KNOCKBACK);
        }
    }
    public override void EndState()
    {
        base.EndState();
        
    }
}
