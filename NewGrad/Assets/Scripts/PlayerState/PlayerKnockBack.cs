using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어의 넉백.
public class PlayerKnockBack : PlayerParent
{
    public override void BeginState()
    {
        base.BeginState();
        manager.ySpeed = -1.5f;
        if (manager.iteratingEnemy.anim != null)
            manager.iteratingEnemy.anim.SetInteger("AttackType", 5);
        manager.GetComponent<CharacterController>().Move(new Vector3(2 * Time.deltaTime/2, -manager.ySpeed * Time.deltaTime, 0));
    }
    private void Update()
    {
        manager.controller.Move(-manager.speed * Time.deltaTime/2);

        if (manager.losed)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (manager.CardDeckUI.transform.GetChild(0).childCount > 0)
                    manager.CardDeckUI.transform.GetChild(0).GetChild(0).GetComponent<CardParent>().KeyBordInput();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (manager.CardDeckUI.transform.GetChild(0).childCount > 1)
                    manager.CardDeckUI.transform.GetChild(0).GetChild(1).GetComponent<CardParent>().KeyBordInput();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (manager.CardDeckUI.transform.GetChild(0).childCount > 2)
                    manager.CardDeckUI.transform.GetChild(0).GetChild(2).GetComponent<CardParent>().KeyBordInput();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (manager.CardDeckUI.transform.GetChild(0).childCount > 3)
                    manager.CardDeckUI.transform.GetChild(0).GetChild(3).GetComponent<CardParent>().KeyBordInput();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (manager.CardDeckUI.transform.GetChild(0).childCount > 4)
                    manager.CardDeckUI.transform.GetChild(0).GetChild(4).GetComponent<CardParent>().KeyBordInput();
            }
        }

        if (manager.ySpeed >=1.5f)
            manager.SetState(PlayerState.IDLE);
    }
    public override void EndState()
    {
        base.EndState();
    }
}
