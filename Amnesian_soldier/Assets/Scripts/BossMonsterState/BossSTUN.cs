using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSTUN : BossParent
{
    public float temp;
    public override void BeginState()
    {
        temp = 5.0f;
    }
    private void Update()
    {
        temp -= Time.deltaTime;

        if(PlayerManager.playerSingleton.attackType==AttackType.HORIZON)
        {
            PlayerManager.playerSingleton.attackType = AttackType.NONE;
            manager.hp -= PlayerManager.playerSingleton.weapon.weaponDamage;
        }

        if (temp <= 0)
            manager.SetState(BossState.IDLE);
    }
    public override void EndState()
    {
        base.EndState();
    }
}
