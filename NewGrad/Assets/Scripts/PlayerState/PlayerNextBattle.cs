using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNextBattle : PlayerParent
{
    float gage;
    float gageTemp;
    public override void BeginState()
    {
        base.BeginState();
        manager.fillCanvas.SetActive(true);
        gage = 0.5f;
        gageTemp = 0;
    }
    private void Update()
    {
        manager.controller.Move(manager.speed * Time.deltaTime);
        manager.iteratingEnemy.GetComponent<CharacterController>().Move(manager.speed * Time.deltaTime);

        gageTemp += Time.deltaTime;
        manager.fillCanvas.GetComponentInChildren<Image>().fillAmount = gageTemp / gage;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (manager.CardDeckUI.transform.GetChild(0).childCount > 0)
                manager.CardDeckUI.transform.GetChild(1).GetComponent<CardParent>().KeyBordInput();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (manager.CardDeckUI.transform.GetChild(0).childCount > 1)
                manager.CardDeckUI.transform.GetChild(2).GetComponent<CardParent>().KeyBordInput();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (manager.CardDeckUI.transform.GetChild(0).childCount > 2)
                manager.CardDeckUI.transform.GetChild(0).GetChild(0).GetComponent<CardParent>().KeyBordInput();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (manager.CardDeckUI.transform.GetChild(0).childCount > 3)
                manager.CardDeckUI.transform.GetChild(0).GetChild(1).GetComponent<CardParent>().KeyBordInput();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (manager.CardDeckUI.transform.GetChild(0).childCount > 4)
                manager.CardDeckUI.transform.GetChild(0).GetChild(2).GetComponent<CardParent>().KeyBordInput();
        }
        if (manager.attackType.Count != 0
            || gageTemp>=gage)
        {
            manager.fillCanvas.SetActive(false);
            manager.SetState(PlayerState.MONSTERBATTLE);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
