using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStore : StageParent
{
    public override void BeginState()
    {
        base.BeginState();
        
        PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
        PlayerManager.playerSingleton.anim.SetBool("Rest", true);

        manager.StoreCanvas.SetActive(true);
        manager.StoreCanvas.transform.GetChild(0).gameObject.SetActive(false);
        manager.StoreCanvas.GetComponent<StoreManager>().InitializeTime();
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }

    
}
