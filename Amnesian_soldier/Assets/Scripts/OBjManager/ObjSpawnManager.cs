using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawnManager : MonoBehaviour
{
    public GameObject[] nearObj;
    public GameObject farobj;
    public static Queue<GameObject> NearObjsQueue = new Queue<GameObject>();
    public static Queue<GameObject> FarObjsQueue = new Queue<GameObject>();
    public static Queue<GameObject> MidObjsQueue = new Queue<GameObject>();
    public static Queue<GameObject> NearBgQueue = new Queue<GameObject>();
    public static Queue<GameObject> BG = new Queue<GameObject>();
    public int StartNearSpawnAmount;
    public int StartNearBgAmount;
    public int StartFarSawnAmount;
    public int startMidSpawnAmount;
    public int startBG;
    public Color32 nearObjColor;
    public GameObject midObj;
    int PlayerXPos;
    int PlayerFarXPOS;
    int playerMidXPOS;
    int playerNearBgXPos;
    int playerBGXPos;

    public GameObject[] nearBgTrees;
    public GameObject[] nearBgGrass;

    public GameObject[] midBgWeeds;
    public GameObject[] midBgTrees;
    public GameObject[] midBgBush;

    public GameObject[] farBgGrass;
    public GameObject[] farBgTree;
    public GameObject[] farBgLeaves;
    public GameObject BackGroundSky;

    static int NearbgbackAmount =0;
    static int midBgBackAmount= 0;
    static int FarbgbackAmount=0;

    private void Awake()
    {
        NearObjsQueue.Clear();
        FarObjsQueue.Clear();

    }
    private void Start()
    {
        PlayerXPos = 1;
        PlayerFarXPOS = 0;
        playerMidXPOS = 0;
        playerNearBgXPos = 0;
        playerBGXPos = 0;
        nearObjColor = new Color(157, 195, 226);
        for (int i = -5; i <= StartNearSpawnAmount; i++)
            NearObjSpawn(new Vector3((i - 1) * 2, 0.4f, 1.5f));

        for (int i = -20; i <= StartFarSawnAmount; i++)
            farObjSpawn(new Vector3(i * 1, 0, 16));

        for (int i=-5; i<=startMidSpawnAmount; i++)
        {
            MidObjSpawn(new Vector3((i * 2.0f), 0.4f, 10.0f));
        }

        for(int i=-5; i< StartNearBgAmount; i++)
        {
            NearBackSpawn(new Vector3((i * 3.0f), 0.55f, 3.0f));
        }

        
    }
    private void FixedUpdate()
    {
        if (PlayerManager.playerSingleton.transform.position.x - PlayerXPos >= 2)
        {
            Destroy(NearObjsQueue.Dequeue());
            StartNearSpawnAmount++;

            NearObjSpawn(new Vector3((StartNearSpawnAmount - 1) * 2, 0.4f,1.5f));
            PlayerXPos = (int)PlayerManager.playerSingleton.transform.position.x;
        }
        if (PlayerManager.playerSingleton.transform.position.x - playerNearBgXPos >= 3)
        {
            Destroy(NearBgQueue.Dequeue());
            StartNearBgAmount++;

            NearBackSpawn(new Vector3((StartNearBgAmount - 1) * 3, 0.5f, 3f));
            playerNearBgXPos = (int)PlayerManager.playerSingleton.transform.position.x;
        }
        if (PlayerManager.playerSingleton.transform.position.x - PlayerFarXPOS >= 1)
        {
            Destroy(FarObjsQueue.Dequeue());
            StartFarSawnAmount++;
            farObjSpawn(new Vector3((StartFarSawnAmount - 1) * 1, 0, 16));
            PlayerFarXPOS = (int)PlayerManager.playerSingleton.transform.position.x;
        }
        if (PlayerManager.playerSingleton.transform.position.x - playerMidXPOS >= 2.0f)
        {
            Destroy(MidObjsQueue.Dequeue());
            startMidSpawnAmount++;
            MidObjSpawn(new Vector3((startMidSpawnAmount - 1) * 2.0f, 0.4f, 10.0f));
            playerMidXPOS = (int)PlayerManager.playerSingleton.transform.position.x;
        }
        
    }

    public void NearObjSpawn(Vector3 pos)
    {
        GameObject near = Instantiate(nearObj[Utilities.NewRandom(0, nearObj.Length)], transform.GetChild(0));
        near.transform.localPosition = pos;
        NearObjsQueue.Enqueue(near);
    }

    public void NearBackSpawn(Vector3 pos)
    {
        NearbgbackAmount += 1;
        if (NearbgbackAmount > 5)
            NearbgbackAmount = 0;
        float isTree = Utilities.NewRandom(0,10);
        if(isTree >=8)
        {
            GameObject nearBg = Instantiate(nearBgTrees[Utilities.NewRandom(0, nearBgTrees.Length)], transform.GetChild(1));
            nearBg.transform.localPosition = pos + new Vector3(0,4,0);
            nearBg.GetComponent<SpriteRenderer>().sortingOrder = NearbgbackAmount;
            //nearBg.GetComponent<SpriteRenderer>().color = nearObjColor;
            NearBgQueue.Enqueue(nearBg);
        }
        else
        {
            GameObject nearBg = Instantiate(nearBgGrass[Utilities.NewRandom(0, nearBgGrass.Length)], transform.GetChild(1));
            nearBg.transform.localPosition = pos + new Vector3(0, 0, 0);
            //nearBg.GetComponent<SpriteRenderer>().color = nearObjColor;
            nearBg.GetComponent<SpriteRenderer>().sortingOrder = NearbgbackAmount;
            NearBgQueue.Enqueue(nearBg);
        }

    }

    public void farObjSpawn(Vector3 pos)
    {
        float isTree = Random.Range(0, 0.015f);
        if (isTree <= 0.005f)
        {
            GameObject farBg = Instantiate(farBgGrass[Utilities.NewRandom(0, farBgGrass.Length)], transform.GetChild(2));
            farBg.transform.localPosition = pos + new Vector3(0, 0.5f, 0);

            FarObjsQueue.Enqueue(farBg);
        }
        else if (isTree >= 0.009f)
        {
            GameObject farBg = Instantiate(farBgTree[Utilities.NewRandom(0, farBgTree.Length)], transform.GetChild(2));
            farBg.transform.localPosition = pos + new Vector3(0, 5, -1);

            FarObjsQueue.Enqueue(farBg);
        }
        else
        {
            GameObject farBg = Instantiate(farBgLeaves[Utilities.NewRandom(0, farBgLeaves.Length)], transform.GetChild(2));
            farBg.transform.localPosition = pos + new Vector3(0, 12, -4);

            FarObjsQueue.Enqueue(farBg);
        }
    }

    public void MidObjSpawn(Vector3 pos)
    {
        

        float isTree = Random.Range(0, 0.015f);
        if (isTree <=0.005f)
        {
            GameObject midBg = Instantiate(midBgBush[Utilities.NewRandom(0, midBgBush.Length)], transform.GetChild(3));
            midBg.transform.localPosition = pos + new Vector3(0, 0, 0);
            
            MidObjsQueue.Enqueue(midBg);
        }
        else if(isTree >=0.012f)
        {
            GameObject midBg = Instantiate(midBgTrees[Utilities.NewRandom(0, midBgTrees.Length)], transform.GetChild(3));
            midBg.transform.localPosition = pos + new Vector3(0,5,0);
            
            MidObjsQueue.Enqueue(midBg);
        }
        else
        {
            GameObject midBg = Instantiate(midBgWeeds[Utilities.NewRandom(0, midBgWeeds.Length)], transform.GetChild(3));
            midBg.transform.localPosition = pos + new Vector3(0, 0, 0);
            
            MidObjsQueue.Enqueue(midBg);
        }
    }

    public void BackGroundSpawn(Vector3 pos)
    {
        GameObject sky = Instantiate(BackGroundSky, transform.GetChild(4));
        sky.transform.localPosition = pos;
        BG.Enqueue(sky);
    }
}
