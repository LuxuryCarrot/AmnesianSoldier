using System.Collections;
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
            StageManager.stageSingletom.HitKillSpawn(transform.position, true);
            CameraManager.camSingleTon.SetState(CamState.SHAKE);
        }

        if (temp <= 0)
        {
            manager.SetState(BossState.WAKE);
            manager.anim.SetBool("Stun", false);
        }

        if (transform.position.x - PlayerManager.playerSingleton.transform.position.x >= 4.0f)
            return;
        else
            transform.position
            = new Vector3(PlayerManager.playerSingleton.transform.position.x + 4.0f, 3.5f, 0);
    }
    public override void EndState()
    {
        base.EndState();
    }
}
