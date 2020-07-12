using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//맵에 표시되는 노드.
public class MapNode : MonoBehaviour
{
    //시작 노드를 표시하는 시작노드
    public static MapNode StartNode;
    //끝 노드.
    public static MapNode EndNode=null;
    //앞노드, 뒷노드를 지정함.
    public MapNode[] beforeNode;
    public MapNode[] afterNodes;
    public bool isEnabled=false;
    public int mapNum;
    public StageState stateWhenStart;
    public string mapInfo;
    public static MapNode[] EnabledNode;
    public int stair;
    public string battleInfo;
    public NodeType linkType;

    private void Start()
    {
        //직전 노드가 없는 노드는 시작 노드이므로 시작노드를 초기화.
        if(beforeNode.Length==0 && StartNode ==null)
        {
            StartNode = this;
            //맵 스포너를 붙임.
            MapSpawnerAttach();
            for (int i = 0; i < StartNode.afterNodes.Length; i++)
            {
                StartNode.afterNodes[i].isEnabled = true;
            }
            EnabledNode = afterNodes;
            
            StageManager.stageSingletom.mapSelectCanvas.SetActive(false);
            StageManager.stageSingletom.mapCanvas.SetActive(false);
        }
        
    }

    //클릭시 이 노드를 비활성화 하고, 맵을 붙임.
    public void Activate()
    {


        if (!isEnabled)
            return;
        
        for (int j = 0; j < beforeNode.Length; j++)
        {
            for (int i = 0; i < beforeNode[j].afterNodes.Length; i++)
            {
                beforeNode[j].afterNodes[i].isEnabled = false;
            }
        }
        if(afterNodes.Length==0)
        {
            EndNode = this;
            Debug.Log("!!!!");
        }
        else
        for (int i = 0; i< afterNodes.Length; i++)
        {
            afterNodes[i].isEnabled = true;
        }
        MapSpawnerAttach();
        
        if (afterNodes.Length != 0)
        {
            MapNode.EnabledNode = null;
            MapNode.EnabledNode = afterNodes;
        }
        else
            MapNode.EnabledNode = null;
        StageManager.stageSingletom.SetState(stateWhenStart);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/MapResources/"+battleInfo+"_Active");
        
            
        StageManager.stageSingletom.mapCanvas.SetActive(false);
        
        StageManager.stageSingletom.mapSelectCanvas.SetActive(false);
    }

    //맵을 불러옴. 
    public void MapSpawnerAttach()
    {
        if(MapPositionManager.field.transform.childCount!=0)
          Destroy(MapPositionManager.field.transform.GetChild(0).gameObject);
        GameObject newSpawner = Instantiate(Resources.Load("Prefabs/MapSpawners/Map" + mapInfo + "Spawner") as GameObject, MapPositionManager.field.transform);
    }
}
