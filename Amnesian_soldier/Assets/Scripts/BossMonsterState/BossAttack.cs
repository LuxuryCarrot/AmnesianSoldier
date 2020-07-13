using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttack : BossParent
{
    float temp;
    public override void BeginState()
    {
        base.BeginState();
        temp = 3;
        if (manager.attacktQueue.Count != 0)
            manager.attacktQueue.Clear();
        for(int i=0; i<manager.attackAmount; i++)
        {
            AttackType newtype = Random.Range(0, 0.001f) >= 0.0005f ? AttackType.GUARD : AttackType.HORIZON;
            GameObject typeIcon = Instantiate(
                Resources.Load("Prefabs/Cards/EmptyCard") as GameObject, manager.AttackCanvas.transform);
            typeIcon.GetComponent<Image>().sprite =
                newtype == AttackType.GUARD ? Resources.Load<Sprite>("Sprites/protect") :
                Resources.Load<Sprite>("Sprites/attack");
            typeIcon.transform.localPosition = new Vector3((i-2), 3.5f, 0);
            manager.attacktQueue.Enqueue(newtype);
        }

        manager.CastingBar.SetActive(true);
        PlayerManager.playerSingleton.SetState(PlayerState.BOSSBATTLE);
    }
    private void Update()
    {
        temp -= Time.deltaTime;
        manager.CastingBar.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().fillAmount = temp / 3;
        if(temp<=0)
        {
            temp = 100;
            manager.anim.SetTrigger("heavyAttack");
            PlayerManager.playerSingleton.SetState(PlayerState.IDLE);
            manager.SetState(BossState.IDLE);
        }
    }
    public override void EndState()
    {
        base.EndState();
        if (manager != null)
            manager.CastingBar.SetActive(false);
        for (; transform.GetChild(1).childCount != 0;)
        {
            GameObject thisButton = transform.GetChild(1).GetChild(0).gameObject;
            thisButton.transform.SetParent(null);
            Destroy(thisButton);
        }
    }
}
