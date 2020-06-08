using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카드를 게임에 불러오는 함수. 
public class CardSpawner : MonoBehaviour
{
    public GameObject card;

    //업데이트 문에서 덱에서 카드를 불러옴. 
    private void Update()
    {
        for(; transform.childCount<5; )
        {
            if (DeckList.Deck.Count == 0)
                break;

            GameObject newCard = Instantiate(card, transform);
            newCard.GetComponent<CardParent>().DecideCard(DeckList.Deck.Dequeue());
        }
    }
}
