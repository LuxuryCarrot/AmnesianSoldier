using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//앞으로 전진하는 코드
public class PlayerIdle : PlayerParent
{
    public bool AimIn;
    public bool attackIn;
    public float attackTemp;
    
    public override void BeginState()
    {
        base.BeginState();
        AimIn = false;
        manager.anim.SetBool("Ready", false);
        //manager.AimChange(false);
        attackTemp = 0.5f;
        attackIn = false;
        manager.stamRestore = 0.5f;
    }
    private void Update()
    {
        manager.controller.Move(manager.speedIncrease * manager.speed*Time.deltaTime);

        if(manager.stamRestore > 0)
        {
            manager.stamRestore -= Time.deltaTime;
        }
        else
        {
            if(manager.stam<100)
               manager.stam += Time.deltaTime*33;
        }

        if( AimIn && (manager.attackType!=AttackType.NONE || (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)))
            && manager.iteratingEnemy.current!=EnemyState.DIE)
        {
            if (manager.stam >=0 && (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)))
                manager.SetState(PlayerState.ABANDON);
            else
                manager.SetState(PlayerState.MONSTERBATTLE);
        }

        if(manager.iteratingEnemy!=null && manager.iteratingEnemy.current != EnemyState.DIE
            && manager.iteratingEnemy.transform.position.x - transform.position.x <=manager.AimEndRange-1
            && StageManager.stageSingletom.current!=StageState.MAPSELECT)
        {
            if (manager.stam >= 0 && (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)))
                manager.SetState(PlayerState.ABANDON);
            else
                manager.SetState(PlayerState.MONSTERBATTLE);
        }

        if(manager.iteratingEnemy!=null
            && manager.iteratingEnemy.transform.position.x - transform.position.x <= manager.AimStartRange+1
            &&!AimIn)
        {
            
            AimIn = true;
           
        }


        if (Input.GetMouseButton(1) && manager.stam >=0)
        {
            manager.anim.SetBool("Guarding", true);
            manager.attackType = AttackType.GUARD;
            manager.stamRestore = 0.5f;
            if (manager.stam >0)
               manager.stam -= Time.deltaTime * 33;
            attackIn = false;
            
        }
        else if (Input.GetMouseButtonDown(0) && attackIn == false)
        {
            attackIn = true;
            manager.weapon.Execute();
        }
        else if(!attackIn)
        {
            manager.attackType = AttackType.NONE;
            manager.anim.SetBool("Guarding", false);
            manager.anim.SetBool("Charging", false);
        }

        if(attackIn)
        {
            attackTemp -= Time.deltaTime;
            if(attackTemp <=0)
            {
                attackIn = false;
                attackTemp = 0.5f;
                manager.attackType = AttackType.NONE;
            }
        }
        
    }
    public override void EndState()
    {
        base.EndState();
        
    }
}
