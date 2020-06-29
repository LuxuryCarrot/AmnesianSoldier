using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWait : EnemyParent
{
    //가장 기본적인 상태
    void Update()
    {
        if (transform.position.x - PlayerManager.playerSingleton.transform.position.x <= manager.range &&
            transform.position.x - PlayerManager.playerSingleton.transform.position.x >= 0
            && PlayerManager.playerSingleton.current == PlayerState.IDLE
            && PlayerManager.playerSingleton.iteratingEnemy == null
            )
        {
            
            PlayerManager.playerSingleton.iteratingEnemy = manager;
            if (manager.awakeBehavior != null)
                manager.awakeBehavior.Execute();
        }
        else if(transform.position.x - PlayerManager.playerSingleton.transform.position.x <=2 &&
            PlayerManager.playerSingleton.current==PlayerState.PINN
            && manager.hp <=2
            && PlayerManager.playerSingleton.iteratingEnemy!=manager)
        {
            manager.hp = 0;
            manager.SetState(EnemyState.KNOCKBACK);
        }

        if(transform.position.x - PlayerManager.playerSingleton.transform.position.x <= manager.attRange
            && manager.attackType == AttackType.HORIZON)
        {
            manager.anim.SetTrigger("Attack");
        }
    }
}
