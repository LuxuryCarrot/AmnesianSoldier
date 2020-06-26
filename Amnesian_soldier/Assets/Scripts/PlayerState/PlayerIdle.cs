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
        manager.AimChange(false);
        attackTemp = 0.5f;
        attackIn = false;
    }
    private void Update()
    {
        manager.controller.Move(manager.speedIncrease * manager.speed*Time.deltaTime);

        if(AimIn && (manager.attackType!=AttackType.NONE || (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space))))
        {
            if (manager.stam >=0 && (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space)))
                manager.SetState(PlayerState.ABANDON);
            else
                manager.SetState(PlayerState.MONSTERBATTLE);
        }

        if(manager.iteratingEnemy!=null
            &&manager.iteratingEnemy.transform.position.x - transform.position.x <=manager.AimEndRange-1)
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
            
           
            manager.AimChange(true);
            //StageManager.stageSingletom.aimCanvas.transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
            //for (int i = 0; i < manager.inputSlot.transform.childCount; i++)
            //    manager.inputSlot.transform.GetChild(i).GetComponent<CardParent>().DestroyThis();
        }


        if (Input.GetMouseButton(1) && manager.stam >=0)
        {
            manager.anim.SetBool("Charging", true);
            manager.attackType = AttackType.GUARD;
            if(manager.stam >0)
               manager.stam -= Time.deltaTime * 10;
            attackIn = false;
            
        }
        else if (Input.GetMouseButtonDown(0) && attackIn == false)
        {
            attackIn = true;
            manager.anim.SetBool("Success", true);
            manager.anim.SetBool("Charging", false);
            manager.attackType = AttackType.HORIZON;
        }
        else if(!attackIn)
        {
            manager.attackType = AttackType.NONE;
            manager.anim.SetBool("Charging", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (manager.stam > 10)
                manager.stam -= 10;
            else
                manager.stam = 0;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if (manager.stam > 0)
                manager.stam -= Time.deltaTime * 10;
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
        //키보드 입력으로 화살표를 사출하는 코드
        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
            
        //        manager.CardDeckUI.transform.GetChild(1).GetComponent<CardParent>().KeyBordInput();
        //}
        //else if(Input.GetKeyDown(KeyCode.Alpha2))
        //{
            
        //        manager.CardDeckUI.transform.GetChild(2).GetComponent<CardParent>().KeyBordInput();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    if (manager.CardDeckUI.transform.GetChild(0).childCount >= 1)
        //        manager.CardDeckUI.transform.GetChild(0).GetChild(0).GetComponent<CardParent>().KeyBordInput();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    if (manager.CardDeckUI.transform.GetChild(0).childCount >= 2)
        //        manager.CardDeckUI.transform.GetChild(0).GetChild(1).GetComponent<CardParent>().KeyBordInput();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    if (manager.CardDeckUI.transform.GetChild(0).childCount >= 3)
        //        manager.CardDeckUI.transform.GetChild(0).GetChild(2).GetComponent<CardParent>().KeyBordInput();
        //}

        //if(AimIn)
        //{
        //    Camera.main.fieldOfView = BattleDetermine.FloatSlerp(Camera.main.fieldOfView, manager.minCamScale, 2*Time.deltaTime);
        //}
        //else
        //{
        //    Camera.main.fieldOfView = BattleDetermine.FloatSlerp(Camera.main.fieldOfView, manager.maxCamScale, 2*Time.deltaTime);
        //}
    
    }
    public override void EndState()
    {
        base.EndState();
        
    }
}
