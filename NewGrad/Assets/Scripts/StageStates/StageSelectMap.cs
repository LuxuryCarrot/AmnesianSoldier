using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//맵을 고르는 상태.
public class StageSelectMap : StageParent
{
    public float temp;
    public override void BeginState()
    {
        base.BeginState();
        temp = 5;
        PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
        manager.mapCanvas.SetActive(true);
        manager.mapSelectCanvas.SetActive(true);
        if(manager.mapSelectCanvas.transform.childCount!=0)
            for(int i=0; i< manager.mapSelectCanvas.transform.GetChild(0).GetChild(2).childCount; i++)
            {
                manager.mapSelectCanvas.transform.GetChild(0).GetChild(2).GetChild(i).GetComponent<MapSelectCard>().DestroyThis();
            }

        if(MapNode.EnabledNode!=null)
        {
            for(int i=0; i<MapNode.EnabledNode.Length; i++)
            {
                
                GameObject nextcard = Instantiate(Resources.Load("Prefabs/UIPrefab/MapSelect"+ MapNode.EnabledNode[i].battleInfo) as GameObject, manager.mapSelectCanvas.transform.GetChild(0).GetChild(2));
                //nextcard.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/stage_select" + MapNode.EnabledNode[i].battleInfo + "_enemy") as Sprite;
                nextcard.GetComponent<RectTransform>().localPosition += new Vector3(300 + (i - 1) * 600, 0, 0);
                nextcard.transform.GetChild(0).GetComponent<MapSelectCard>().linkedNode = MapNode.EnabledNode[i];
            }
        }
    }
    private void Update()
    {
        temp -= Time.deltaTime;
        manager.MapselectLimitTime.text = ((int)temp).ToString();
        manager.MapselectLimitTimeShadow.text = ((int)temp).ToString();
        if (temp<=0)
        {
            temp = 5;
            
            manager.mapSelectCanvas.transform.GetChild(0).GetChild(2)
                .GetChild(Random.Range(0, manager.mapSelectCanvas.transform.GetChild(0).GetChild(2).childCount - 1))
                .GetChild(0)
                .GetComponent<MapSelectCard>().OnPointerClick();
            
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
