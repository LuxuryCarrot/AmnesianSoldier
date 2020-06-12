using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHP : CardParent
{
    public int hpIncrease;
    public override void KeyBordInput()
    {
        //base.KeyBordInput();
        transform.SetParent(null);
        if (hpIncrease + PlayerManager.playerSingleton.HP >= 3)
            PlayerManager.playerSingleton.HP = 3;
        else
            PlayerManager.playerSingleton.HP+=hpIncrease;

        StageManager.stageSingletom.HPText.text = PlayerManager.playerSingleton.HP.ToString();

        StageManager.stageSingletom.CardDeck.GetComponent<CardSpawner>().DrawCard();
        Destroy(this.gameObject);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        //base.OnPointerClick(eventData);
        transform.SetParent(null);
        if (hpIncrease + PlayerManager.playerSingleton.HP >= 3)
            PlayerManager.playerSingleton.HP = 3;
        else
            PlayerManager.playerSingleton.HP += hpIncrease;
        StageManager.stageSingletom.HPText.text = PlayerManager.playerSingleton.HP.ToString();
        StageManager.stageSingletom.CardDeck.GetComponent<CardSpawner>().DrawCard();
        Destroy(this.gameObject);
    }
}
