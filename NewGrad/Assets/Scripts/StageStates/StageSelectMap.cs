using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//맵을 고르는 상태.
public class StageSelectMap : StageParent
{
    public override void BeginState()
    {
        base.BeginState();
        PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
        manager.mapCanvas.SetActive(true);
        manager.mapSelectCanvas.SetActive(true);
        if(manager.mapSelectCanvas.transform.childCount!=0)
            for(int i=0; i< manager.mapSelectCanvas.transform.childCount; i++)
            {
                manager.mapSelectCanvas.transform.GetChild(i).GetComponent<MapSelectCard>().DestroyThis();
            }

        if(MapNode.EnabledNode!=null)
        {
            for(int i=0; i<MapNode.EnabledNode.Length; i++)
            {
                
                GameObject nextcard = Instantiate(Resources.Load("Prefabs/UIPrefab/MapSelectCardPrefab") as GameObject, manager.mapSelectCanvas.transform);
                nextcard.GetComponent<RectTransform>().localPosition = new Vector3(300 + (i - 1) * 600, 0, 0);
                nextcard.GetComponent<MapSelectCard>().linkedNode = MapNode.EnabledNode[i];
            }
        }
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
