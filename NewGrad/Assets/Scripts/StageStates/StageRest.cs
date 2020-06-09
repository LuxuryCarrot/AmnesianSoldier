using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRest : StageParent
{
    public override void BeginState()
    {
        base.BeginState();
        PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if (manager.mapCanvas.activeInHierarchy)
                manager.mapCanvas.SetActive(false);
            else
                manager.mapCanvas.SetActive(true);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
