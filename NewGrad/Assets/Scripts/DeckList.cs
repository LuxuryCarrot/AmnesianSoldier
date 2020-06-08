using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckList : MonoBehaviour
{
    //실제 인게임에 적용되는 덱 큐
    public static Queue<string> Deck = new Queue<string>();

    //외부에서 불러오는 카드 목록.
    public string[] decklistInst;


    private void Awake()
    {
        if(decklistInst.Length!=0 && Deck.Count==0)
        {
            //외부에서 카드 목록을 불러와서 임시 리스트에 넣음
            List<string> containerDeck = new List<string>();
            for(int i=0; i<decklistInst.Length; i++)
            {
                containerDeck.Add(decklistInst[i]);
                Debug.Log("Contained");
            }

            //임시 리스트에서 랜덤 드로우 해서 실제 덱에 넣음.
            for(; containerDeck.Count!=0; )
            {
                string putout = containerDeck[Random.Range(0, containerDeck.Count)];
                Deck.Enqueue(putout);
                containerDeck.Remove(putout);
            }
        }
    }
}
