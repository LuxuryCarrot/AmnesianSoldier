using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRest : StageParent
{
    public float temp;

    public override void BeginState()
    {
        base.BeginState();
        temp = 5;
        PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
        manager.RestCanvas.SetActive(true);
        manager.RestCanvas.transform.GetChild(2).gameObject.SetActive(false);
        //manager.mapSelectCanvas.SetActive(true);
        //if (manager.mapSelectCanvas.transform.GetChild(0).GetChild(2).childCount != 0)
        //    for (int i = 0; manager.mapSelectCanvas.transform.GetChild(0).GetChild(2).childCount != 0; i++)
        //    {
        //        manager.mapSelectCanvas.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<MapSelectCard>().DestroyThis();
        //    }

        //if (MapNode.EnabledNode != null)
        //{
        //    for (int i = 0; i < MapNode.EnabledNode.Length; i++)
        //    {

        //        GameObject nextcard = Instantiate(Resources.Load("Prefabs/UIPrefab/MapSelect" + MapNode.EnabledNode[i].battleInfo) as GameObject, manager.mapSelectCanvas.transform.GetChild(0).GetChild(2));
        //        //nextcard.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/stage_select" + MapNode.EnabledNode[i].battleInfo + "_enemy") as Sprite;
        //        nextcard.GetComponent<RectTransform>().localPosition += new Vector3(300 + (i - 1) * 600, 0, 0);
        //        nextcard.transform.GetChild(0).GetComponent<MapSelectCard>().linkedNode = MapNode.EnabledNode[i];
        //    }
        //}
        //manager.mapCanvas.SetActive(true);
        //manager.mapCanvas.transform.GetChild(0).localPosition = Vector3.zero;
        //manager.mapCanvas.transform.GetChild(0).localRotation = Quaternion.Euler(0, 0, -90);
    }
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.M))
        //{
        //    if (manager.mapSelectCanvas.activeInHierarchy)
        //    {
        //        manager.mapCanvas.SetActive(false);
        //        manager.mapSelectCanvas.SetActive(false);
        //    }
        //    else
        //    {
        //        manager.mapSelectCanvas.SetActive(true);
        //        manager.mapCanvas.SetActive(true);
        //    }
        //}
        //if(Input.GetKeyDown(KeyCode.N))
        //{
        //    if (manager.mapCanvas.activeInHierarchy)
        //    {
        //        manager.mapCanvas.transform.GetChild(0).localPosition = new Vector3(0, 1190, 0);
        //        manager.mapCanvas.SetActive(false);

        //        //manager.mapSelectCanvas.SetActive(false);
        //    }
        //    else
        //    {
        //        manager.mapCanvas.SetActive(true);
        //        manager.mapCanvas.transform.GetChild(0).localPosition = Vector3.zero;
        //        //manager.mapCanvas.SetActive(true);
        //    }
        //}

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
        if (MapNode.EndNode != null)
        {
            manager.mapCanvas.transform.GetChild(0).localPosition = new Vector3(0, 1190, 0);
            manager.SetState(StageState.GAMECLEAR);

        }
        else
        {
            manager.mapCanvas.transform.GetChild(0).localPosition = new Vector3(0, 1190, 0);
            //Destroy(MapPositionManager.field.transform.GetChild(0).gameObject);
            manager.SetState(StageState.MAPSELECT);
        }
    }
}
