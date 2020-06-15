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

    private void Awake()
    {
        prefab = Resources.Load("Prefabs/MapSpawners/MapNodePrefab") as GameObject;
        maxStair = MaxStage - MaxToBoss;
        MaxMaps = (int)Mathf.Pow(2, (float)MaxToBoss);

        MapImage = this.gameObject;

        for(int i=1; i<maxStair; i++)
        {
            float seed = Random.Range(0, 0.01f);
            if(startNode==null)
            {
                GameObject newNode = Instantiate(prefab, MapImage.transform);
                newNode.GetComponent<MapNode>().stair = 0;
                startNode = newNode;
                mapNodeCurrent = startNode;
                if(seed >=0.005f)
                {
                    GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                    newNode1.GetComponent<MapNode>().stair = 2;
                    newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                    newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                    GameObject newNode2 = Instantiate(prefab, MapImage.transform);
                    newNode2.GetComponent<MapNode>().stair = 2;
                    newNode2.GetComponent<MapNode>().beforeNode = new MapNode[1];
                    newNode2.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                    mapDetermineQueue.Enqueue(newNode1);
                    mapDetermineQueue.Enqueue(newNode2);
                    mapNodeCurrent.GetComponent<MapNode>().afterNodes = new MapNode[2];
                    mapNodeCurrent.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();
                    mapNodeCurrent.GetComponent<MapNode>().afterNodes[1] = newNode2.GetComponent<MapNode>();
                }
                else
                {
                    GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                    newNode1.GetComponent<MapNode>().stair = 2;
                    newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                    newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                    mapDetermineQueue.Enqueue(newNode1);
                    mapNodeCurrent.GetComponent<MapNode>().afterNodes = new MapNode[1];
                    mapNodeCurrent.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();
                }
            }
            else
            {
                if (mapDetermineQueue.Peek().GetComponent<MapNode>().stair == i)
                {
                    mapNodeCurrent = mapDetermineQueue.Dequeue();
                    if (seed >= 0.005f && mapDetermineQueue.Count + 1 < MaxMaps)
                    {
                        GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                        newNode1.GetComponent<MapNode>().stair = i + 1;
                        newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                        newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                        GameObject newNode2 = Instantiate(prefab, MapImage.transform);
                        newNode2.GetComponent<MapNode>().stair = i + 1;
                        newNode2.GetComponent<MapNode>().beforeNode = new MapNode[1];
                        newNode2.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                        mapDetermineQueue.Enqueue(newNode1);
                        mapDetermineQueue.Enqueue(newNode2);
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes = new MapNode[2];
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes[1] = newNode2.GetComponent<MapNode>();
                    }
                    else
                    {
                        GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                        newNode1.GetComponent<MapNode>().stair = i+1;
                        newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                        newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                        mapDetermineQueue.Enqueue(newNode1);
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes = new MapNode[1];
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();
                    }
                }
            }
        }
        for(int i=maxStair; i<maxStair+MaxToBoss; i++)
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
                    mapDetermineQueue.Enqueue(newNode1);
                }
                else
                {
                    backNode1.GetComponent<MapNode>().afterNodes = new MapNode[1];
                    backNode1.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();

                    newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                    newNode1.GetComponent<MapNode>().beforeNode[0] = backNode1.GetComponent<MapNode>();
                    mapDetermineQueue.Enqueue(newNode1);
                }
            }

        }
    }

    
}
