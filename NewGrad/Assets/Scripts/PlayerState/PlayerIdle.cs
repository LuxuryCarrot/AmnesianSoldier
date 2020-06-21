using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//앞으로 전진하는 코드
public class PlayerIdle : PlayerParent
{
    public bool AimIn;
    public override void BeginState()
    {
        base.BeginState();
        AimIn = false;
        manager.anim.SetBool("Ready", false);
        manager.AimChange(false);
    }
    private void Update()
    {
        manager.controller.Move(manager.speed*Time.deltaTime);

        if(AimIn && manager.attackType.Count!=0)
        {
            manager.SetState(PlayerState.MONSTERBATTLE);
        }

        if(manager.iteratingEnemy!=null
            &&manager.iteratingEnemy.transform.position.x - transform.position.x <=manager.AimEndRange-1)
        {
            
            manager.SetState(PlayerState.MONSTERBATTLE);
        }

        if(manager.iteratingEnemy!=null
            && manager.iteratingEnemy.transform.position.x - transform.position.x <= manager.AimStartRange+1
            &&!AimIn)
        {
            
            AimIn = true;
            manager.attackType.Clear();
           
            manager.AimChange(true);
            //StageManager.stageSingletom.aimCanvas.transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
            //for (int i = 0; i < manager.inputSlot.transform.childCount; i++)
            //    manager.inputSlot.transform.GetChild(i).GetComponent<CardParent>().DestroyThis();
        }

        //키보드 입력으로 화살표를 사출하는 코드
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            
                manager.CardDeckUI.transform.GetChild(1).GetComponent<CardParent>().KeyBordInput();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            
                manager.CardDeckUI.transform.GetChild(2).GetComponent<CardParent>().KeyBordInput();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (manager.CardDeckUI.transform.GetChild(0).childCount >= 1)
                manager.CardDeckUI.transform.GetChild(0).GetChild(0).GetComponent<CardParent>().KeyBordInput();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (manager.CardDeckUI.transform.GetChild(0).childCount >= 2)
                manager.CardDeckUI.transform.GetChild(0).GetChild(1).GetComponent<CardParent>().KeyBordInput();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (manager.CardDeckUI.transform.GetChild(0).childCount >= 3)
                manager.CardDeckUI.transform.GetChild(0).GetChild(2).GetComponent<CardParent>().KeyBordInput();
        }

        if(AimIn)
        {
            Camera.main.fieldOfView = BattleDetermine.FloatSlerp(Camera.main.fieldOfView, manager.minCamScale, 2*Time.deltaTime);
        }
        else
        {
            Camera.main.fieldOfView = BattleDetermine.FloatSlerp(Camera.main.fieldOfView, manager.maxCamScale, 2*Time.deltaTime);
        }
    
    }
    public override void EndState()
    {
        base.EndState();
        
    }
}
