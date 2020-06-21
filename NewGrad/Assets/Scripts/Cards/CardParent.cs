using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardParent : MonoBehaviour, IPointerClickHandler
{
    public bool isExecuted=false;
    public bool isParented = false;
    public AttackType thisType;
    float temp = 0.3f;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(isParented && PlayerManager.playerSingleton.iteratingEnemy==null)
        {
            temp -= Time.deltaTime;
            if (temp <= 0)
            {
                PlayerManager.playerSingleton.attackType.Clear();
                PlayerManager.playerSingleton.anim.SetInteger("AttackType", 5);
                PlayerManager.playerSingleton.anim.SetBool("Cancel", true);
                for (int i = 0; i < PlayerManager.playerSingleton.inputSlot.transform.childCount; i++)
                    PlayerManager.playerSingleton.inputSlot.transform.GetChild(i).GetComponent<CardParent>().DestroyThis();
                
                
            }
        }
    }

    

    //클릭하면 카드를 플레이어에게 옮겨붙이는 기능
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        //카드가 없을때만 붙이도록 비교문 넣어둠
        KeyBordInput();
        //transform.SetParent(PlayerManager.playerSingleton.inputSlot.transform);
        //GetComponent<Image>().color = Color.clear;
        //GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
        //if (PlayerManager.playerSingleton.current==PlayerState.IDLE
        //    && !PlayerManager.playerSingleton.GetComponent<PlayerIdle>().AimIn)
        //    PlayerManager.playerSingleton.anim.SetInteger("AttackType", (int)thisType);
        //GetComponent<RectTransform>().localPosition = new Vector3(PlayerManager.playerSingleton.inputSlot.transform.childCount-1, 1.5f, 0);
        //StageManager.stageSingletom.CardDeck.GetComponent<CardSpawner>().DrawCard();
    }
    //키보드를 입력받을 시, 스테이지 매니저에서 발동하는 함수
    public virtual void KeyBordInput()
    {
        if (thisType == AttackType.VERTICAL
            && StageManager.stageSingletom.BlueAttackCurrent <= 0)
            return;
        else if (thisType == AttackType.HORIZON
            && StageManager.stageSingletom.RedAttackCurrent <= 0)
            return;

        if ( isExecuted == true || PlayerManager.playerSingleton.inputSlot.transform.childCount >=5 
            || PlayerManager.playerSingleton.current == PlayerState.ABANDON
            || PlayerManager.playerSingleton.current == PlayerState.MONSTERBATTLE)
            return;
        //isExecuted = true;
        //isParented = true;
        PlayerManager.playerSingleton.attackType.Enqueue(thisType);
        PlayerManager.playerSingleton.anim.SetInteger("AttackType", (int)thisType);
        if (thisType == AttackType.GUARD)
        {
            transform.SetParent(null);
            StageManager.stageSingletom.CardDeck.GetComponent<CardSpawner>().DrawCard();
            DestroyThis();
        }
        else if (thisType == AttackType.VERTICAL)
            StageManager.stageSingletom.BlueAttackCurrent--;
        else if (thisType == AttackType.HORIZON)
            StageManager.stageSingletom.RedAttackCurrent--;
        //transform.SetParent(PlayerManager.playerSingleton.inputSlot.transform);
        //GetComponent<Image>().color = Color.clear;
        //GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
        //if (PlayerManager.playerSingleton.current == PlayerState.IDLE
        //    && !PlayerManager.playerSingleton.GetComponent<PlayerIdle>().AimIn)
        //    PlayerManager.playerSingleton.anim.SetInteger("AttackType", (int)thisType);
        //GetComponent<RectTransform>().localPosition = new Vector3(PlayerManager.playerSingleton.inputSlot.transform.childCount - 1, 1.5f, 0);
        //StageManager.stageSingletom.CardDeck.GetComponent<CardSpawner>().DrawCard();
    }
    //public bool canUseCard()
    //{

    //}
    //초기화 시 카드의 타입을 초기화하는 기능.
    
    public virtual void DestroyThis()
    {
        transform.SetParent(null);
        Destroy(this.gameObject);
    }
}
