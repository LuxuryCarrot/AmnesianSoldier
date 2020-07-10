using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum NodeType
{
    UP=0,
    DOWN,
    NONE
}

public class MapNodeLinker : MonoBehaviour
{
    public int EliteMap;
    public int RestMap;
    public int MaxStage;
    public int StoreMap;
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
    public static string beforeType = "";
    public GameObject UpLinkImage;
    public GameObject DownLinkImage;
    public GameObject UpDownLinkImage;
    public GameObject DownDownLinkImage;
    public GameObject StraightLinkImage;

    private void Awake()
    {
        prefab = Resources.Load("Prefabs/MapSpawners/MapNodePrefab") as GameObject;
        maxStair = MaxStage - MaxToBoss;
        //MaxMaps = (int)Mathf.Pow(2, (float)MaxToBoss);
        MaxMaps = 6;
        MapImage = this.gameObject;

        for(int i=0; i<maxStair-1; i++)
        {
            float seed = Random.Range(1, 1.001f); 
            if(startNode==null)
            {
                GameObject newNode = Instantiate(prefab, MapImage.transform);
                newNode.transform.localPosition = new Vector3(-300, -20, 0);
                newNode.GetComponent<MapNode>().mapInfo = stageNum + "_1Default";
                newNode.GetComponent<MapNode>().battleInfo = "_Default";
                newNode.GetComponent<MapNode>().stair = 0;
                startNode = newNode;
                mapNodeCurrent = startNode;
                newNode.GetComponent<Image>().sprite =
                         Resources.Load<Sprite>("Sprites/MapResources/" + newNode.GetComponent<MapNode>().battleInfo + "_Active");
                newNode.GetComponent<Image>().SetNativeSize();
                //if(seed >=0.005f)
                //{
                GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                newNode1.GetComponent<MapNode>().mapInfo = stageNum + "_2Default";
                newNode1.GetComponent<MapNode>().battleInfo = "_Default";
                newNode1.GetComponent<MapNode>().stair = 1;
                    newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                    newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                newNode1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(102, 63, 0);

                GameObject linker1 = Instantiate(UpLinkImage, MapImage.transform);
                linker1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(42, 40, 0);

                    GameObject newNode2 = Instantiate(prefab, MapImage.transform);
                newNode1.GetComponent<MapNode>().linkType = NodeType.UP;

                newNode2.GetComponent<MapNode>().mapInfo = stageNum + "_2Rest";
                newNode2.GetComponent<MapNode>().battleInfo = "_Rest";
                newNode2.GetComponent<MapNode>().stateWhenStart = StageState.REST;
                newNode2.GetComponent<MapNode>().stair = 1;
                
                newNode2.GetComponent<MapNode>().beforeNode = new MapNode[1];
                    newNode2.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                newNode2.transform.localPosition = newNode2.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(102, -63, 0);

                GameObject linker2 = Instantiate(DownLinkImage, MapImage.transform);
                linker2.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(42, -40, 0);

                newNode2.GetComponent<MapNode>().linkType = NodeType.DOWN;
                mapDetermineQueue.Enqueue(newNode1);
                newNode1.GetComponent<Image>().sprite =
                         Resources.Load<Sprite>("Sprites/MapResources/" + newNode1.GetComponent<MapNode>().battleInfo + "_InActive");
                newNode1.GetComponent<Image>().SetNativeSize();
                mapDetermineQueue.Enqueue(newNode2);
                newNode2.GetComponent<Image>().sprite =
                         Resources.Load<Sprite>("Sprites/MapResources/" + newNode2.GetComponent<MapNode>().battleInfo + "_InActive");
                newNode2.GetComponent<Image>().SetNativeSize();
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
                    beforeType = mapNodeCurrent.GetComponent<MapNode>().battleInfo;
                    if (
                        seed >=1.00005f &&
                         mapDetermineQueue.Count + 1 < MaxMaps && mapNodeCurrent.GetComponent<MapNode>().linkType!=NodeType.NONE)
                    {
                        GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                        DetermineNodeType(newNode1, i+2);
                        newNode1.GetComponent<MapNode>().stair = i + 1;
                        newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                        newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                        
                        GameObject newNode2 = Instantiate(prefab, MapImage.transform);
                        DetermineNodeType(newNode2, i+2);
                        newNode2.GetComponent<MapNode>().stair = i + 1;
                        newNode2.GetComponent<MapNode>().beforeNode = new MapNode[1];
                        newNode2.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                       
                        mapDetermineQueue.Enqueue(newNode1);
                        mapDetermineQueue.Enqueue(newNode2);
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes = new MapNode[2];
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();
                        mapNodeCurrent.GetComponent<MapNode>().afterNodes[1] = newNode2.GetComponent<MapNode>();

                        if(mapNodeCurrent.GetComponent<MapNode>().linkType==NodeType.UP)
                        {
                            newNode1.GetComponent<MapNode>().linkType = NodeType.UP;
                            newNode1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(102, 63, 0);

                            GameObject linker1 = Instantiate(UpLinkImage, MapImage.transform);
                            linker1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(42, 40, 0);

                            newNode2.GetComponent<MapNode>().linkType = NodeType.NONE;
                            newNode2.transform.localPosition = newNode2.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(102, 0, 0);

                            GameObject linker2 = Instantiate(StraightLinkImage, MapImage.transform);
                            linker2.transform.localPosition = newNode2.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(42, 0, 0);
                        }
                        else if(mapNodeCurrent.GetComponent<MapNode>().linkType == NodeType.DOWN)
                        {
                            newNode1.GetComponent<MapNode>().linkType = NodeType.NONE;
                            newNode1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(102, 0, 0);

                            GameObject linker1 = Instantiate(StraightLinkImage, MapImage.transform);
                            linker1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(42, 0, 0);

                            newNode2.GetComponent<MapNode>().linkType = NodeType.DOWN;
                            newNode2.transform.localPosition = newNode2.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(102, -63, 0);

                            GameObject linker2 = Instantiate(DownLinkImage, MapImage.transform);
                            linker2.transform.localPosition = newNode2.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(42, -40, 0);
                        }
                    }
                    else
                    {
                        GameObject newNode1 = Instantiate(prefab, MapImage.transform);
                        DetermineNodeType(newNode1, i+2);
                        newNode1.GetComponent<MapNode>().stair = i+1;
                        newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                        newNode1.GetComponent<MapNode>().linkType = mapNodeCurrent.GetComponent<MapNode>().linkType;
                        newNode1.GetComponent<MapNode>().beforeNode[0] = mapNodeCurrent.GetComponent<MapNode>();
                        newNode1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(102, 0, 0);

                        GameObject linker1 = Instantiate(StraightLinkImage, MapImage.transform);
                        linker1.transform.localPosition = newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition + new Vector3(42, 0, 0);

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
                GameObject newNode1 = Instantiate(prefab);
                DetermineNodeType(newNode1, i+1);
                newNode1.GetComponent<MapNode>().stair = i + 1;
                GameObject backNode1 = BackNodes.Dequeue();
                beforeType = backNode1.GetComponent<MapNode>().battleInfo;
                if (BackNodes.Count!=0)
                {
                    GameObject backNode2 = BackNodes.Dequeue();
                    backNode1.GetComponent<MapNode>().afterNodes = new MapNode[1];
                    backNode1.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();

                    GameObject linker1 = Instantiate(DownDownLinkImage, MapImage.transform);
                    linker1.transform.localPosition = backNode1.transform.localPosition + new Vector3(60, -19, 0);

                    backNode2.GetComponent<MapNode>().afterNodes = new MapNode[1];
                    backNode2.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();

                    GameObject linker2 = Instantiate(UpDownLinkImage, MapImage.transform);
                    linker2.transform.localPosition = backNode2.transform.localPosition + new Vector3(60, 19, 0);

                    newNode1.transform.SetParent(MapImage.transform);

                    newNode1.GetComponent<MapNode>().beforeNode = new MapNode[2];
                    newNode1.GetComponent<MapNode>().beforeNode[0] = backNode1.GetComponent<MapNode>();
                    newNode1.GetComponent<MapNode>().beforeNode[1] = backNode2.GetComponent<MapNode>();
                    newNode1.transform.localPosition =
                        (newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition +
                        newNode1.GetComponent<MapNode>().beforeNode[1].transform.localPosition) / 2
                        + new Vector3(102, 0, 0);
                    mapDetermineQueue.Enqueue(newNode1);
                }
                else
                {
                    backNode1.GetComponent<MapNode>().afterNodes = new MapNode[1];
                    backNode1.GetComponent<MapNode>().afterNodes[0] = newNode1.GetComponent<MapNode>();

                    GameObject linker1 = Instantiate(StraightLinkImage, MapImage.transform);
                    linker1.transform.localPosition = backNode1.transform.localPosition + new Vector3(60, 0, 0);

                    newNode1.transform.SetParent(MapImage.transform);

                    newNode1.GetComponent<MapNode>().beforeNode = new MapNode[1];
                    newNode1.GetComponent<MapNode>().beforeNode[0] = backNode1.GetComponent<MapNode>();
                    newNode1.transform.localPosition =
                       newNode1.GetComponent<MapNode>().beforeNode[0].transform.localPosition +
                       
                       new Vector3(102, 0, 0);
                    mapDetermineQueue.Enqueue(newNode1);
                }
            }

        }
    }
    public void DetermineNodeType(GameObject node, int stairNum)
    {
        float randomSeed = Random.Range(0, 0.12f);
        if(stairNum == MaxStage)
        {
            deftype = "_Boss";
            node.GetComponent<MapNode>().battleInfo = "_Boss";
            node.GetComponent<MapNode>().mapInfo = stageNum.ToString() + "_" +  "Boss";
        }
        else if(randomSeed <=0.015f && EliteMap>0&&deftype!="_Elite" && beforeType != "_Elite")
        {
            deftype =  "_Elite";
            node.GetComponent<MapNode>().battleInfo = "_Elite";
            node.GetComponent<MapNode>().mapInfo = stageNum.ToString() + "_" + stairNum.ToString() + "Elite";
            
            EliteMap--;
        }
        else if(randomSeed > 0.015f && randomSeed <=0.03f && RestMap>0 && deftype != "_Rest" && beforeType != "_Rest")
        {
            deftype =  "_Rest";
            node.GetComponent<MapNode>().battleInfo = "_Rest";
            
            node.GetComponent<MapNode>().mapInfo = stageNum.ToString() + "_" + stairNum.ToString() + "Rest";
            node.GetComponent<MapNode>().stateWhenStart = StageState.REST;
            RestMap--;
        }
        else if (randomSeed > 0.03f && randomSeed <= 0.045f && StoreMap > 0 && deftype != "_Store" && beforeType != "_Store")
        {
            deftype = "_Store";
            node.GetComponent<MapNode>().battleInfo = "_Store";
            node.GetComponent<MapNode>().mapInfo = stageNum.ToString() + "_" + stairNum.ToString() + "Store";
            node.GetComponent<MapNode>().stateWhenStart = StageState.STORE;
            StoreMap--;
        }
        else
        {
            deftype =  "_Default";
            node.GetComponent<MapNode>().battleInfo = "_Default";
            node.GetComponent<MapNode>().mapInfo = stageNum.ToString() + "_" + stairNum.ToString() + "Elite";
            
        }
        node.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Sprites/MapResources/" + node.GetComponent<MapNode>().battleInfo + "_InActive");
        node.GetComponent<Image>().SetNativeSize();
    }

    
}
