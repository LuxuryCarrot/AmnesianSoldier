using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRest : StageParent
{
    public override void BeginState()
    {
        base.BeginState();
        PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
        manager.mapSelectCanvas.SetActive(true);
        if (manager.mapSelectCanvas.transform.GetChild(0).GetChild(2).childCount != 0)
            for (int i = 0; manager.mapSelectCanvas.transform.GetChild(0).GetChild(2).childCount != 0; i++)
            {
                manager.mapSelectCanvas.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<MapSelectCard>().DestroyThis();
            }

        if (MapNode.EnabledNode != null)
        {
            for (int i = 0; i < MapNode.EnabledNode.Length; i++)
            {

                GameObject nextcard = Instantiate(Resources.Load("Prefabs/UIPrefab/MapSelect" + MapNode.EnabledNode[i].battleInfo) as GameObject, manager.mapSelectCanvas.transform.GetChild(0).GetChild(2));
                //nextcard.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/stage_select" + MapNode.EnabledNode[i].battleInfo + "_enemy") as Sprite;
                nextcard.GetComponent<RectTransform>().localPosition += new Vector3(300 + (i - 1) * 600, 0, 0);
                nextcard.transform.GetChild(0).GetComponent<MapSelectCard>().linkedNode = MapNode.EnabledNode[i];
            }
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if (manager.mapSelectCanvas.activeInHierarchy)
            {
                manager.mapCanvas.SetActive(false);
                manager.mapSelectCanvas.SetActive(false);
            }
            else
            {
                manager.mapSelectCanvas.SetActive(true);
                manager.mapCanvas.SetActive(true);
            }
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
