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
            )
        {
            if (PlayerManager.playerSingleton.iteratingEnemy == null)
                PlayerManager.playerSingleton.iteratingEnemy = manager;
            if (manager.awakeBehavior != null)
                manager.awakeBehavior.Execute();
        }
    }
}
