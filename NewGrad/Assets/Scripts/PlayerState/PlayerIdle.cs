using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//앞으로 전진하는 코드
public class PlayerIdle : PlayerParent
{
    public override void BeginState()
    {
        base.BeginState();
    }
    private void Update()
    {
        manager.controller.Move(manager.speed*Time.deltaTime);
        if(manager.iteratingEnemy!=null
            &&manager.iteratingEnemy.transform.position.x - transform.position.x <=manager.range)
        {
            manager.SetState(PlayerState.MONSTERBATTLE);
        }

        //키보드 입력으로 화살표를 사출하는 코드
        if(Input.GetKeyDown(KeyCode.W))
        {
            for(int i=0; i<manager.CardDeckUI.transform.GetChild(0).childCount; i++)
            {
                if(manager.CardDeckUI.transform.GetChild(0).GetChild(i).GetComponent<CardParent>().thisType ==AttackType.UP)
                {
                    manager.CardDeckUI.transform.GetChild(0).GetChild(i).GetComponent<CardParent>().KeyBordInput();
                    break;
                }
            }
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < manager.CardDeckUI.transform.GetChild(0).childCount; i++)
            {
                if (manager.CardDeckUI.transform.GetChild(0).GetChild(i).GetComponent<CardParent>().thisType == AttackType.LEFT)
                {
                    manager.CardDeckUI.transform.GetChild(0).GetChild(i).GetComponent<CardParent>().KeyBordInput();
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < manager.CardDeckUI.transform.GetChild(0).childCount; i++)
            {
                if (manager.CardDeckUI.transform.GetChild(0).GetChild(i).GetComponent<CardParent>().thisType == AttackType.RIGHT)
                {
                    manager.CardDeckUI.transform.GetChild(0).GetChild(i).GetComponent<CardParent>().KeyBordInput();
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < manager.CardDeckUI.transform.GetChild(0).childCount; i++)
            {
                if (manager.CardDeckUI.transform.GetChild(0).GetChild(i).GetComponent<CardParent>().thisType == AttackType.DOWN)
                {
                    manager.CardDeckUI.transform.GetChild(0).GetChild(i).GetComponent<CardParent>().KeyBordInput();
                    break;
                }
            }
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
