using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : EnemyParent
{
    public override void BeginState()
    {
        base.BeginState();
        //StageManager.stageSingletom.SlowMotionStart();
        CameraManager.camSingleTon.SetState(CamState.SHAKE);
        if (PlayerManager.playerSingleton.iteratingEnemy == manager)
        {
            PlayerManager.playerSingleton.iteratingEnemy = null;
            PlayerManager.playerSingleton.SetState(PlayerState.IDLE);
        }
        GetComponent<CharacterController>().enabled = false;
        if (manager.dieBehavior != null)
            manager.dieBehavior.Begin();

        for (int i = 0; i < transform.GetChild(1).childCount; i++)
            Destroy(transform.GetChild(1).GetChild(i).gameObject);
        if (manager.anim != null && manager.dieBehavior == null)
            manager.anim.SetTrigger("Die");

        SkillRoot();
        StageManager.stageSingletom.KillCount++;

        //if (manager.RootingCardPool.Length > 0)
        //{
        //    DeckList.Deck.Enqueue(manager.RootingCardPool[Random.Range(0, manager.RootingCardPool.Length)]);
        //    StageManager.stageSingletom.DeckCountText.text = DeckList.Deck.Count.ToString();
        //    if (StageManager.stageSingletom.CardDeck.transform.childCount < 3)
        //        StageManager.stageSingletom.CardDeck.GetComponent<CardSpawner>().DrawCard();
        //}
        //else if(manager.RootingAttPool.Length>0)
        //{
        //    string root = manager.RootingAttPool[Random.Range(0, manager.RootingAttPool.Length)];
        //    if (root == "blue" && StageManager.stageSingletom.BlueAttackCurrent < StageManager.stageSingletom.BlueAttackAmount)
            
        //        StageManager.stageSingletom.BlueAttackCurrent++;

        //    else if(root == "red" && StageManager.stageSingletom.RedAttackCurrent < StageManager.stageSingletom.RedAttackAmount)
        //        StageManager.stageSingletom.RedAttackCurrent++;
        //}
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

    public void SkillRoot()
    {
        
        float randSeed = Random.Range(0, 0.1f);

        if(randSeed>=0.05f)
        {
           
            if (manager.RootingCardPool.Length>0)
            {
                GameObject newSkill = Instantiate(
                    Resources.Load("Prefabs/Cards/" +
                    manager.RootingCardPool[Random.Range(0, manager.RootingCardPool.Length)]) as GameObject);

                StageManager.stageSingletom.SkillAdd(newSkill);
            }
        }
    }
}
