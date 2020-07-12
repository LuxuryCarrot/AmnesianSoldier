﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSTUN : BossParent
{
    public float temp;
    public override void BeginState()
    {
        temp = 5.0f;
        manager.anim.SetBool("Stun", true);
    }
    private void Update()
    {
        temp -= Time.deltaTime;

        if(PlayerManager.playerSingleton.attackType==AttackType.HORIZON)
        {
            PlayerManager.playerSingleton.attackType = AttackType.NONE;
            manager.hp -= PlayerManager.playerSingleton.weapon.weaponDamage;
            CameraManager.camSingleTon.SetState(CamState.SHAKE);
        }

        if (temp <= 0)
        {
            manager.SetState(BossState.IDLE);
            manager.anim.SetBool("Stun", false);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
