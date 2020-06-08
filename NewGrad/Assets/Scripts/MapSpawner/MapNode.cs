using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//맵에 표시되는 노드.
public class MapNode : MonoBehaviour, IPointerClickHandler
{
    //시작 노드를 표시하는 시작노드
    public static MapNode StartNode;
    //끝 노드.
    public static MapNode EndNode=null;
    //앞노드, 뒷노드를 지정함.
    public MapNode beforeNode;
    public MapNode[] afterNodes;
    bool isEnabled=false;
    public int mapNum;

    private void Awake()
    {
        //직전 노드가 없는 노드는 시작 노드이므로 시작노드를 초기화.
        if(beforeNode==null && StartNode ==null)
        {
            StartNode = this;
            //맵 스포너를 붙임.
            MapSpawnerAttach();
            for (int i = 0; i < StartNode.afterNodes.Length; i++)
            {
                StartNode.afterNodes[i].isEnabled = true;
            }
            StageManager.stageSingletom.mapCanvas.SetActive(false);
        }
        
    }

    //클릭시 이 노드를 비활성화 하고, 맵을 붙임.
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isEnabled)
            return;

        for(int i=0; i<beforeNode.afterNodes.Length; i++)
        {
            beforeNode.afterNodes[i].isEnabled = false;
        }
        
        if(afterNodes.Length==0)
        {
            EndNode = this;
        }

        for (int i = 0; i< afterNodes.Length; i++)
        {
            afterNodes[i].isEnabled = true;
        }
        MapSpawnerAttach();
        StageManager.stageSingletom.SetState(StageState.READY);
        StageManager.stageSingletom.mapCanvas.SetActive(false);
    }

    //맵을 불러옴. 
    public void MapSpawnerAttach()
    {
        
        GameObject newSpawner = Instantiate(Resources.Load("Prefabs/MapSpawners/Map1_" + "1" + "Spawner") as GameObject, MapPositionManager.field.transform);
    }
}
