using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRest : StageParent
{
    public float temp;

    public override void BeginState()
    {
        base.BeginState();
        temp = 15;
        PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
        PlayerManager.playerSingleton.anim.SetBool("Rest", true);
        manager.RestCanvas.SetActive(true);
        manager.RestCanvas.transform.GetChild(2).gameObject.SetActive(false);
        StageManager.stageSingletom.mapCanvas.SetActive(true);
        StageManager.stageSingletom.mapCanvas.transform.GetChild(0).localPosition = Vector3.zero;

    }
    private void Update()
    {
        
        if(!StageManager.stageSingletom.mapCanvas.activeInHierarchy)
           temp -= Time.deltaTime;

        if(temp <=0)
        {
            manager.RestCanvas.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }

    public void RestTypeSelected()
    {
        manager.RestCanvas.transform.GetChild(2).gameObject.SetActive(false);
        manager.mapCanvas.SetActive(false);
        if (MapNode.EndNode != null)
        {
            //manager.mapCanvas.transform.GetChild(0).localPosition = new Vector3(0, 1190, 0);
            manager.SetState(StageState.GAMECLEAR);

        }
        else
        {
            //manager.mapCanvas.transform.GetChild(0).localPosition = new Vector3(0, 1190, 0);
            //Destroy(MapPositionManager.field.transform.GetChild(0).gameObject);
            manager.SetState(StageState.MAPSELECT);
        }
    }
}
