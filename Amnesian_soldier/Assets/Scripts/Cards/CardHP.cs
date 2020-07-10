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
        if (hpIncrease + PlayerManager.playerSingleton.HP >= 5)
            PlayerManager.playerSingleton.HP = 5;
        else
            PlayerManager.playerSingleton.HP+=hpIncrease;

        StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange();
        PlayerManager.playerSingleton.anim.SetTrigger("PotionUse");
        //StageManager.stageSingletom.CardDeck.GetComponent<CardSpawner>().DrawCard();
        StageManager.stageSingletom.SkillUsed();
        Destroy(this.gameObject);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        //base.OnPointerClick(eventData);
        transform.SetParent(null);
        if (hpIncrease + PlayerManager.playerSingleton.HP >= 5)
            PlayerManager.playerSingleton.HP = 5;
        else
            PlayerManager.playerSingleton.HP += hpIncrease;
        StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange();
        PlayerManager.playerSingleton.anim.SetTrigger("PotionUse");
        //StageManager.stageSingletom.CardDeck.GetComponent<CardSpawner>().DrawCard();
        Destroy(this.gameObject);
    }
}
