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
        AttackType playerType=AttackType.NONE;
        if (manager.attackType.Count != 0)
            playerType = manager.attackType.Dequeue();
        for (int i = 0; i < manager.inputSlot.transform.childCount; i++)
            manager.inputSlot.transform.GetChild(i).GetComponent<CardParent>().DestroyThis();

        if(manager.losed)
        {
            manager.iteratingEnemy = null;
            manager.attackType.Clear();
            manager.SetState(PlayerState.ABANDON);
            return;
        }

        if (BattleDetermine.Determine(playerType, manager.iteratingEnemy.attackType) ==BattleResult.WIN)
        {
            MonsterManager.Monsters.Remove(manager.iteratingEnemy.gameObject);
            StageManager.stageSingletom.WinFlashCanvas.SetActive(true);
            Destroy(manager.iteratingEnemy.gameObject);
            manager.iteratingEnemy = null;
            manager.attackType.Clear();
            manager.SetState(PlayerState.IDLE);
        }
        else if(playerType == AttackType.NONE)
        {
            manager.iteratingEnemy = null;
            StageManager.stageSingletom.LoseFlashCanvas.SetActive(true);
            manager.HP--;
            StageManager.stageSingletom.HPText.text = manager.HP.ToString();
            manager.attackType.Clear();
            manager.SetState(PlayerState.ABANDON);
        }
        else if(BattleDetermine.Determine(playerType, manager.iteratingEnemy.attackType) == BattleResult.LOSE)
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
