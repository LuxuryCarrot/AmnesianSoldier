using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카드를 게임에 불러오는 함수. 
public class CardSpawner : MonoBehaviour
{
    public GameObject card;

    //업데이트 문에서 덱에서 카드를 불러옴. 
    private void Start()
    {
        for (; transform.childCount < 5;)
            DrawCard();
    }
    private void Update()
    {
        
    }
    public void DrawCard()
    {
        
            if (DeckList.Deck.Count == 0 || transform.childCount>=5)
                return;

            GameObject newCard = Instantiate(Resources.Load("Prefabs/Cards/"+ DeckList.Deck.Dequeue()) as GameObject, transform);
        StageManager.stageSingletom.DeckCountText.text = DeckList.Deck.Count.ToString();
        
    }
}
