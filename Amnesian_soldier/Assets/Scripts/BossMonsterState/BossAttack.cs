using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttack : BossParent
{
    public override void BeginState()
    {
        base.BeginState();
        for(int i=0; i<manager.attackAmount; i++)
        {
            AttackType newtype = Random.Range(0, 0.001f) >= 0.0005f ? AttackType.GUARD : AttackType.HORIZON;
            GameObject typeIcon = Instantiate(
                Resources.Load("Prefabs/Cards/EmptyCard") as GameObject, manager.AttackCanvas.transform);
            typeIcon.GetComponent<Image>().sprite =
                newtype == AttackType.GUARD ? Resources.Load<Sprite>("Sprites/protect") :
                Resources.Load<Sprite>("Sprites/attack");
        }

        PlayerManager.playerSingleton.SetState(PlayerState.BOSSBATTLE);
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
