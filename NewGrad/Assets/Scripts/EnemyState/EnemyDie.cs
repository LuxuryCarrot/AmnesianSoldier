using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : EnemyParent
{
    public override void BeginState()
    {
        base.BeginState();
        if (manager.dieBehavior != null)
            manager.dieBehavior.Begin();

        if (manager.anim != null)
            manager.anim.SetBool("Die", true);

        if (manager.RootingCardPool.Length > 0)
        {
            DeckList.Deck.Enqueue(manager.RootingCardPool[Random.Range(0, manager.RootingCardPool.Length - 1)]);
            StageManager.stageSingletom.DeckCountText.text = DeckList.Deck.Count.ToString();
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
