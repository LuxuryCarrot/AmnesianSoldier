using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionAwake : EnemyAwakeParent
{

    private void Start()
    {
        manager.hpBar.transform.parent.parent.gameObject.SetActive(false);
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
    }

    public override void Execute()
    {
        base.Execute();
        manager.hpBar.transform.parent.parent.gameObject.SetActive(true);
        transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        manager.anim.SetTrigger("Appear");
    }
}
