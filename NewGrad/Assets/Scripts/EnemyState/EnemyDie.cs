﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : EnemyParent
{
    public override void BeginState()
    {
        base.BeginState();
        if (manager.dieBehavior != null)
            manager.dieBehavior.Begin();

        for (int i = 0; i < transform.GetChild(1).childCount; i++)
            Destroy(transform.GetChild(1).GetChild(i).gameObject);
        if (manager.anim != null && manager.dieBehavior == null)
            manager.anim.SetBool("Die", true);

        if (manager.RootingCardPool.Length > 0)
        {
            DeckList.Deck.Enqueue(manager.RootingCardPool[Random.Range(0, manager.RootingCardPool.Length)]);
            StageManager.stageSingletom.DeckCountText.text = DeckList.Deck.Count.ToString();
            if (StageManager.stageSingletom.CardDeck.transform.childCount < 3)
                StageManager.stageSingletom.CardDeck.GetComponent<CardSpawner>().DrawCard();
        }
        else if(manager.RootingAttPool.Length>0)
        {
            string root = manager.RootingAttPool[Random.Range(0, manager.RootingAttPool.Length)];
            if (root == "blue")
                StageManager.stageSingletom.BlueAttackCurrent++;
            else
                StageManager.stageSingletom.RedAttackCurrent++;
        }
    }
    private void Update()
    {
        if(manager.dieBehavior!=null)
            manager.dieBehavior.Execute();
    }
    public override void EndState()
    {
        base.EndState();
    }
}
