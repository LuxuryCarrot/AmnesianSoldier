using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카드를 게임에 불러오는 함수. 
public class CardSpawner : MonoBehaviour
{
    public GameObject card;
    Vector3 Card1Pos=new Vector3(-85, -27,0);
    Vector3 Card2Pos=new Vector3(58, -27,0);
    Vector3 Card3Pos=new Vector3(201, -27,0);

    bool isAnimWork;

    //업데이트 문에서 덱에서 카드를 불러옴. 
    private void Start()
    {
        for (; transform.childCount < 3;)
            DrawCard();
    }
    private void Update()
    {
        if (isAnimWork)
            SetCardPosAnim();
    }
    public void DrawCard()
    {
        
        if (DeckList.Deck.Count == 0 || transform.childCount >= 3)
        {
            isAnimWork = true;
            return;
        }
        else
        {
            isAnimWork = true;
            GameObject newCard = Instantiate(Resources.Load("Prefabs/Cards/" + DeckList.Deck.Dequeue()) as GameObject, transform);
            newCard.transform.localPosition = new Vector3(454, -27, 0);
            StageManager.stageSingletom.DeckCountText.text = DeckList.Deck.Count.ToString();
        }
        
        
    }

    public void SetCardPosAnim()
    {
        bool thirdBool = true;
        bool secondBool = true;
        bool firstBool = true;

        if (transform.childCount >= 3)
        {
            transform.GetChild(2).localPosition = BattleDetermine.Vector3Slerp(transform.GetChild(2).localPosition, Card3Pos, 10 * Time.deltaTime);
            if (Vector3.SqrMagnitude(transform.GetChild(2).localPosition - Card3Pos) <= 0.01f)
                thirdBool = false;
        }
        else
            thirdBool = false;
        if (transform.childCount >= 2)
        {
            transform.GetChild(1).localPosition = BattleDetermine.Vector3Slerp(transform.GetChild(1).localPosition, Card2Pos, 10 * Time.deltaTime);
            if (Vector3.SqrMagnitude(transform.GetChild(1).localPosition - Card2Pos) <= 0.01f)
                secondBool = false;
        }
        else
            secondBool = false;
        if (transform.childCount >= 1)
        {
            transform.GetChild(0).localPosition = BattleDetermine.Vector3Slerp(transform.GetChild(0).localPosition, Card1Pos, 10 * Time.deltaTime);
            if (Vector3.SqrMagnitude(transform.GetChild(0).localPosition - Card1Pos) <= 0.01f)
                firstBool = false;
        }
        else
            firstBool = false;
        if (!thirdBool
            && !secondBool
            && !firstBool)
            isAnimWork = false;
    }
}
