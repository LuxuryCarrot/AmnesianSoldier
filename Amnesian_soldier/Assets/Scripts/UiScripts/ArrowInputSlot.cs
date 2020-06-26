using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArrowInputSlot : MonoBehaviour, IPointerClickHandler
{
    public AttackType thisType;
    public int cardAmount;

    public void OnPointerClick(PointerEventData eventData)
    {
        //카드가 없을때만 붙이도록 비교문 넣어둠
        //if (cardAmount<=0 || PlayerManager.playerSingleton.inputSlot.transform.childCount >= 5
        //    || PlayerManager.playerSingleton.current == PlayerState.ABANDON)
        //    return;

        //GameObject arrow = Instantiate(Resources.Load("Prefabs/Cards/EmptyCard") as GameObject, PlayerManager.playerSingleton.inputSlot.transform);
        //arrow.GetComponent<EmptyCardDestroyer>().isParented = true;
        //arrow.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        //PlayerManager.playerSingleton.attackType.Enqueue(thisType);
        
        //arrow.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);

        //arrow.GetComponent<RectTransform>().localPosition = new Vector3(PlayerManager.playerSingleton.inputSlot.transform.childCount - 1, 1.5f, 0);
        //cardAmount--;
        //StageManager.stageSingletom.CardDeck.GetComponent<CardSpawner>().DrawCard();
    }
    public void KeyBordInput()
    {
        //카드가 없을때만 붙이도록 비교문 넣어둠
        //if (cardAmount <= 0 || PlayerManager.playerSingleton.inputSlot.transform.childCount >= 5
        //    || PlayerManager.playerSingleton.current == PlayerState.ABANDON)
        //    return;

        //GameObject arrow = Instantiate(Resources.Load("Prefabs/Cards/EmptyCard") as GameObject, PlayerManager.playerSingleton.inputSlot.transform);
        //arrow.GetComponent<EmptyCardDestroyer>().isParented = true;
        //arrow.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        //PlayerManager.playerSingleton.attackType.Enqueue(thisType);

        //arrow.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);

        //arrow.GetComponent<RectTransform>().localPosition = new Vector3(PlayerManager.playerSingleton.inputSlot.transform.childCount - 1, 1.5f, 0);
        //cardAmount--;
    }
}
