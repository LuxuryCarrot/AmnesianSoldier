using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimGet : MonoBehaviour
{
    public void Attack()
    {
        CameraManager.camSingleTon.SetState(CamState.SHAKE);
        if (PlayerManager.playerSingleton.attackType != AttackType.GUARD)
        {
            PlayerManager.playerSingleton.SetState(PlayerState.KNOCKBACK);
            PlayerManager.playerSingleton.anim.SetBool("Damaged", true);
            PlayerManager.playerSingleton.HP -= 2;
            StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange();
        }
        else
            PlayerManager.playerSingleton.anim.SetTrigger("GuardAttack");
    }

    public void HeavyAttack()
    {
        CameraManager.camSingleTon.SetState(CamState.SHAKE);
        PlayerManager.playerSingleton.SetState(PlayerState.KNOCKBACK);
        PlayerManager.playerSingleton.anim.SetBool("Damaged", true);
        PlayerManager.playerSingleton.HP -= 3;
        StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange();
    }

    public void TrapSpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            Ray ray = new Ray(transform.parent.transform.position + new Vector3(i, 0, 0)
                , new Vector3(0, -10, 0));
            RaycastHit hitObj;
            if (Physics.Raycast(ray, out hitObj, 1024))
            {

                hitObj.transform.gameObject.GetComponent<FallingMapBox>().CrashBlock();
            }
        }
        GameObject newTrap = Instantiate(
            Resources.Load("Prefabs/KaizoTrap/FallingTrap") as GameObject);
        newTrap.transform.position = new Vector3(transform.parent.transform.position.x, 0, 0);
    }

    public void EndState()
    {
        GetComponentInParent<BossManager>().SetState(BossState.IDLE);
    }
}
