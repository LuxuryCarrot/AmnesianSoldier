using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPinning : PlayerParent
{
    public override void BeginState()
    {
        base.BeginState();
        manager.iteratingEnemy.transform.position = transform.position + new Vector3(2.5f, 0, 0);
    }
    private void Update()
    {
        manager.stam -= Time.deltaTime * 33;
        manager.controller.Move(manager.speedIncrease * manager.speed * Time.deltaTime);
        manager.iteratingEnemy.transform.position = transform.position + new Vector3(2.5f, 0, 0);

        if (Input.GetMouseButtonDown(0))
        {
            manager.anim.SetTrigger("GuardAttack");
            
            if(manager.iteratingEnemy.hp>1)
            {
                manager.iteratingEnemy.hp--;
            }
            else
            {
                manager.iteratingEnemy.hp--;
                manager.iteratingEnemy = null;
                manager.SetState(PlayerState.IDLE);
            }
        }

        if (Input.GetMouseButtonUp(1) || !Input.GetMouseButton(1) || manager.stam <=0)
        {
            manager.anim.SetBool("Charging", false);
            manager.iteratingEnemy.SetState(EnemyState.KNOCKBACK);
            manager.SetState(PlayerState.IDLE);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }

}
