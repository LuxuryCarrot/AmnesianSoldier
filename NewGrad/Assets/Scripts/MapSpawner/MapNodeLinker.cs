using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeLinker : MonoBehaviour
{
    public int EliteMap;
    public int RestMap;
    public int MaxStage;
    public int MaxToBoss;
    int MaxMaps;
    int maxStair;
    public GameObject mapNodeCurrent;
    Queue<GameObject> mapDetermineQueue = new Queue<GameObject>();
    GameObject startNode;
    GameObject prefab;
    GameObject MapImage;
    public int stageNum;
    public static string deftype="";

    private void Awake()
    {
        prefab = Resources.Load("Prefabs/MapSpawners/MapNodePrefab") as GameObject;
        maxStair = MaxStage - MaxToBoss;
        MaxMaps = (int)Mathf.Pow(2, (float)MaxToBoss);

        MapImage = this.gameObject;

        for(int i=0; i<maxStair-1; i++)
        {
            float seed = Random.Range(1, 1.001f); 
            if(startNode==null)
            {
                GameObject newNode = Instantiate(prefab, MapImage.transform);
                newNode.transform.localPosition = new Vector3(0, -420, 0);
                newNode.GetComponent<MapNode>().mapInfo = stageNum + "_Default";
                newNode.GetComponent<MapNode>().battleInfo = "_Default";
                newNode.GetComponent<MapNode>().stair = 0;
                startNode = newNode;
                mapNodeCurrent = startNode;
                //if(seed >=0.005f)
                //{
                    GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                newNode1.GetComponent<MapNode>().mapInfo = stageNum + "_Default";
                newNode1.GetComponent<MapNode>().battleInfo = "_Default";
                newNode1.GetComponent<MapNode>().stair = 1;
                    newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                    newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                newNode1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(-200, 110, 0);
                    GameObject newNode2 = Instantiate(prefab, MapImage.transform);

                newNode2.GetComponent<MapNode>().mapInfo = stageNum + "_Rest";
                newNode2.GetComponent<MapNode>().battleInfo = "_Rest";
                newNode2.GetComponent<MapNode>().stateWhenStart = StageState.REST;
                newNode2.GetComponent<MapNode>().stair = 1;
                
                newNode2.GetComponent<MapNode>().beforeNode = new MapNode[1];
                    newNode2.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                newNode2.transform.localPosition = newNode2.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(200, 110, 0);
                mapDetermineQueue.Enqueue(newNode1);
                    mapDetermineQueue.Enqueue(newNode2);
                    mapNodeCurrent.GetComponent<MapNode>().afterNodes = new MapNode[2];
                    mapNodeCurrent.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();
                    mapNodeCurrent.GetComponent<MapNode>().afterNodes[1] = newNode2.GetComponent<MapNode>();
                //}
                //else
                //{
                //    GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                //    newNode1.GetComponent<MapNode>().stair = 2;
                //    newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                //    newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                //    mapDetermineQueue.Enqueue(newNode1);
                //    mapNodeCurrent.GetComponent<MapNode>().afterNodes = new MapNode[1];
                //    mapNodeCurrent.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();
                //}
            }
            else
            {
                for (; mapDetermineQueue.Peek().GetComponent<MapNode>().stair == i;)
                {
                    seed = Random.Range(1, 1.0001f);
                    mapNodeCurrent = mapDetermineQueue.Dequeue();
                    if (
                        seed >=1.00005f &&
                         mapDetermineQueue.Count + 1 < MaxMaps)
                    {
                        GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                        DetermineNodeType(newNode1);
                        newNode1.GetComponent<MapNode>().stair = i + 1;
                        newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                        newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                        newNode1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(-400/Mathf.Pow(2,i+1), 110, 0);
                        GameObject newNode2 = Instantiate(prefab, MapImage.transform);
                        DetermineNodeType(newNode2);
                        newNode2.GetComponent<MapNode>().stair = i + 1;
                        newNode2.GetComponent<MapNode>().beforeNode = new MapNode[1];
                        newNode2.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                        newNode2.transform.localPosition = newNode2.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(400 / Mathf.Pow(2, i+1), 110, 0);
                        mapDetermineQueue.Enqueue(newNode1);
                        mapDetermineQueue.Enqueue(newNode2);
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes = new MapNode[2];
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes[1] = newNode2.GetComponent<MapNode>();
                    }
                    else
                    {
                        GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                        DetermineNodeType(newNode1);
                        newNode1.GetComponent<MapNode>().stair = i+1;
                        newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                        newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                        newNode1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(0, 110, 0);
                        mapDetermineQueue.Enqueue(newNode1);
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes = new MapNode[1];
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();
                    }
                }
            }
        }
        for(int i=maxStair-1; i<maxStair+MaxToBoss; i++)
        {
            Queue<GameObject> BackNodes=new Queue<GameObject>();
            for(;mapDetermineQueue.Count!=0 ; )
            {
                //전 노드들을 모두 불러옴
                BackNodes.Enqueue(mapDetermineQueue.Dequeue());
            }
            for(;BackNodes.Count!=0 ; )
            {
                GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                DetermineNodeType(newNode1);
                newNode1.GetComponent<MapNode>().stair = i + 1;
                GameObject backNode1 = BackNodes.Dequeue();
                if(BackNodes.Count!=0)
                {
                    GameObject backNode2 = BackNodes.Dequeue();
                    backNode1.GetComponent<MapNode>().afterNodes = new MapNode[1];
                    backNode1.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();

                    backNode2.GetComponent<MapNode>().afterNodes = new MapNode[1];
                    backNode2.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();

                    newNode1.GetComponent<MapNode>().beforeNode = new MapNode[2];
                    newNode1.GetComponent<MapNode>().beforeNode[0] = backNode1.GetComponent<MapNode>();
                    newNode1.GetComponent<MapNode>().beforeNode[1] = backNode2.GetComponent<MapNode>();
                    newNode1.transform.localPosition =
                        (newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition +
                        newNode1.GetComponent<MapNode>().beforeNode[1].transform.localPosition) / 2
                        + new Vector3(0, 110, 0);
                    mapDetermineQueue.Enqueue(newNode1);
                }
                else
                {
                    backNode1.GetComponent<MapNode>().afterNodes = new MapNode[1];
                    backNode1.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();

                    newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                    newNode1.GetComponent<MapNode>().beforeNode[0] = backNode1.GetComponent<MapNode>();
                    newNode1.transform.localPosition =
                       newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition +
                       
                       new Vector3(0, 110, 0);
                    mapDetermineQueue.Enqueue(newNode1);
                }
            }

        }
    }
    public void DetermineNodeType(GameObject node)
    {
        float randomSeed = Random.Range(0, 0.1f);
        if(randomSeed <=0.015f && EliteMap>0&&deftype!="_Elite")
        {
            deftype = "_Elite";
            node.GetComponent<MapNode>().battleInfo = "_Elite";
            node.GetComponent<MapNode>().mapInfo = stageNum.ToString() + "_Elite";
            
            EliteMap--;
        }
        else if(randomSeed > 0.015f && randomSeed <=0.03f && RestMap>0 && deftype != "_Rest")
        {
            deftype = "_Rest";
            node.GetComponent<MapNode>().battleInfo = "_Rest";
            node.GetComponent<MapNode>().mapInfo = stageNum.ToString() + "_Rest";
            node.GetComponent<MapNode>().stateWhenStart = StageState.REST;
            RestMap--;
        }
        else
        {
            deftype = "_Default";
            node.GetComponent<MapNode>().battleInfo = "_Default";
            node.GetComponent<MapNode>().mapInfo = stageNum.ToString() + "_Default";
            
        }
    }

    
}
