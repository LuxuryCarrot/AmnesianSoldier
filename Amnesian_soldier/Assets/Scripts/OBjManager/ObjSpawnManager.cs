using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawnManager : MonoBehaviour
{
    public GameObject[] nearObj;
    public GameObject[] nearBgTrees;
    public GameObject[] nearBgGrass;

    public GameObject[] nearVines;
    public GameObject[] midVines;
    public GameObject[] farVines;

    public GameObject[] midBgTrees;
    public GameObject[] midBgGrass;

    public GameObject[] farBgGrass;
    public GameObject[] farBgTree;

    public GameObject[] farBGs;
    public GameObject veryFarBG;

    public static Queue<GameObject> NearObjsQueue = new Queue<GameObject>();

    public static Queue<GameObject> NearBgTreeQueue = new Queue<GameObject>();
    public static Queue<GameObject> nearBgGrassQueue = new Queue<GameObject>();

    public static Queue<GameObject> NearVineQueue = new Queue<GameObject>();
    public static Queue<GameObject> MidVineQueue = new Queue<GameObject>();
    public static Queue<GameObject> FarVineQueue = new Queue<GameObject>();

    public static Queue<GameObject> MidBgTreeQueue = new Queue<GameObject>();
    public static Queue<GameObject> MidBgGrassQueue = new Queue<GameObject>();

    public static Queue<GameObject> FarBgTreeQueue = new Queue<GameObject>();
    public static Queue<GameObject> FarBgGrassQueue = new Queue<GameObject>();

    public static Queue<GameObject> FarBGsQueue = new Queue<GameObject>();
    public static Queue<GameObject> VeryFarBGQueue = new Queue<GameObject>();

    float PlayerXPosNearObj;
    float PlayerXPosNearBGGrass;
    float PlayerXPosNearBGVines;
    float PlayerXPosNearBGTree;

    float PlayerXPosMidBGGrass;
    float PlayerXPosFarBGGrass;

    float PlayerXPosMidBGVine;
    float PlayerXPosFarBGVine;

    float PlayerXPosMidBGTree;
    float PlayerXPosFarBGTree;

    float PlayerXPosFarBGCliff;
    float PlayerXPosVeryFarBG;

    public float nearGrassDistance;
    public float nearVineDistance;
    public float nearTreeDistance;

    public float midVineDistance;
    public float midGrassDistance;
    public float farGrassDistance;

    public float midTreeDistance;
    public float farVineDistance;
    public float farTreeDistance;

    public float farBGDistance;
    public float veryFarBGDistance;

    public Vector3 nearGrassDepth;
    public Vector3 nearVineDepth;
    public Vector3 nearTreeDepth;

    public Vector3 midVineDepth;
    public Vector3 midGrassDepth;
    public Vector3 farGrassDepth;

    public Vector3 midTreeDepth;
    public Vector3 farVineDepth;
    public Vector3 farTreeDepth;

    public Vector3 farBGDepth;
    public Vector3 veryFarBGDepth;

    public int StartNearSpawnAmount=0;
    public int StartNearBgGrassSpawnAmount =0;
    public int StartNearBgTreeSpawnAmount = 0;

    public int StartNearVineSpawnAmount = 0;
    public int StartMidVineSpawnAmount = 0;
    public int StartFarVineSpawnAmount = 0;

    public int StartMidBgGrassSpawnAmount = 0;
    public int StartFarBgGrassSpawnAmount = 0;

    public int StartMidBgTreeSpawnAmount = 0;
    public int StartFarBgTreeSpawnAmount = 0;

    public int StartFarBgCliffSpawnAmount = 0;
    public int VeryFarBgSpawnAmount = 0;
   
    Transform player;
    int BGSpawned;

    private void Awake()
    {
        NearObjsQueue.Clear();
        nearBgGrassQueue.Clear();
        NearBgTreeQueue.Clear();
        NearVineQueue.Clear();
        MidVineQueue.Clear();
        FarVineQueue.Clear();
        MidBgGrassQueue.Clear();
        FarBgGrassQueue.Clear();
        MidBgTreeQueue.Clear();
        FarBgTreeQueue.Clear();
        FarBGsQueue.Clear();
        VeryFarBGQueue.Clear();
    }
    private void Start()
    {
        player = PlayerManager.playerSingleton.transform;
        //for (int i = -2; i <= StartNearSpawnAmount; i++)
        //    NearObjSpawn(new Vector3((i - 1) * 2, 0.4f, 1.8f));

        for (int i = -2; i <= StartNearBgGrassSpawnAmount; i++)
            NearGrassSpawn((i) * nearGrassDistance);

        for (int i = -2; i <= StartNearVineSpawnAmount; i++)
            NearVineSpawn((i) * nearVineDistance);

        for (int i = -2; i <= StartNearBgTreeSpawnAmount; i++)
            NearTreeSpawn((i) * nearTreeDistance);

        for (int i = -2; i <= StartMidVineSpawnAmount; i++)
            MidVineSpawn((i) * midVineDistance);

        for (int i = -2; i <= StartMidBgGrassSpawnAmount; i++)
            MidGrassSawn((i) * midGrassDistance);

        for (int i = -2; i <= StartFarBgGrassSpawnAmount; i++)
            FarGrassSpawn((i) * farGrassDistance);

        for (int i = -2; i <= StartMidBgTreeSpawnAmount; i++)
            MidTreeSpawn((i) * midTreeDistance);

        for (int i = -2; i <= StartFarVineSpawnAmount; i++)
            FarVineSpawn((i) * farVineDistance);

        for (int i = -2; i <= StartFarBgTreeSpawnAmount; i++)
            FarTreeSpawn((i) * farTreeDistance);

        for (int i = -2; i <= StartFarBgCliffSpawnAmount; i++)
            FarBGSpawn((i) * farBGDistance);

        for (int i = -2; i <= VeryFarBgSpawnAmount; i++)
            VeryFarBGSpawn((i) * veryFarBGDistance);

    }
    private void FixedUpdate()
    {
        //if (PlayerManager.playerSingleton.transform.position.x - PlayerXPosNearObj >= 2)
        //{
        //    Destroy(NearObjsQueue.Dequeue());
        //    StartNearSpawnAmount++;

        //    NearObjSpawn(new Vector3((StartNearSpawnAmount - 1) * 2, 0.4f, 1.8f));
        //    PlayerXPosNearObj = (int)PlayerManager.playerSingleton.transform.position.x;
        //}

        if (player.position.x - PlayerXPosNearBGGrass >= nearGrassDistance)
        {
            Destroy(nearBgGrassQueue.Dequeue());
            

            NearGrassSpawn(StartNearBgGrassSpawnAmount* nearGrassDistance);
            StartNearBgGrassSpawnAmount++;
            PlayerXPosNearBGGrass = player.position.x;
        }
        if (player.position.x - PlayerXPosNearBGVines >= nearVineDistance)
        {
            Destroy(NearVineQueue.Dequeue());


            NearVineSpawn(StartNearVineSpawnAmount * nearVineDistance);
            StartNearVineSpawnAmount++;
            PlayerXPosNearBGVines = player.position.x;
        }
        if (player.position.x - PlayerXPosNearBGTree >= nearTreeDistance)
        {
            Destroy(NearBgTreeQueue.Dequeue());


            NearTreeSpawn(StartNearBgTreeSpawnAmount * nearTreeDistance);
            StartNearBgTreeSpawnAmount++;
            PlayerXPosNearBGTree = player.position.x;
        }
        if (player.position.x - PlayerXPosMidBGVine >= midVineDistance)
        {
            Destroy(MidVineQueue.Dequeue());


            MidVineSpawn(StartMidVineSpawnAmount * midVineDistance);
            StartMidVineSpawnAmount++;
            PlayerXPosMidBGVine = player.position.x;
        }
        if (player.position.x - PlayerXPosMidBGGrass >= midGrassDistance)
        {
            Destroy(MidBgGrassQueue.Dequeue());


            MidGrassSawn(StartMidBgGrassSpawnAmount * midGrassDistance);
            StartMidBgGrassSpawnAmount++;
            PlayerXPosMidBGGrass = player.position.x;
        }
        if (player.position.x - PlayerXPosFarBGGrass >= farGrassDistance)
        {
            Destroy(FarBgGrassQueue.Dequeue());


            FarGrassSpawn(StartFarBgGrassSpawnAmount * farGrassDistance);
            StartFarBgGrassSpawnAmount++;
            PlayerXPosFarBGGrass = player.position.x;
        }
        if (player.position.x - PlayerXPosMidBGTree >= midTreeDistance)
        {
            Destroy(MidBgTreeQueue.Dequeue());


            MidTreeSpawn(StartMidBgTreeSpawnAmount * midTreeDistance);
            StartMidBgTreeSpawnAmount++;
            PlayerXPosMidBGTree = player.position.x;
        }
        if (player.position.x - PlayerXPosFarBGVine >= farVineDistance)
        {
            Destroy(FarVineQueue.Dequeue());


            FarVineSpawn(StartFarVineSpawnAmount * farVineDistance);
            StartFarVineSpawnAmount++;
            PlayerXPosFarBGVine = player.position.x;
        }
        if (player.position.x - PlayerXPosFarBGTree >= farTreeDistance)
        {
            Destroy(FarBgTreeQueue.Dequeue());


            FarTreeSpawn(StartFarBgTreeSpawnAmount * farTreeDistance);
            StartFarBgTreeSpawnAmount++;
            PlayerXPosFarBGTree = player.position.x;
        }
        if (player.position.x - PlayerXPosFarBGCliff >= farBGDistance)
        {
            Destroy(FarBGsQueue.Dequeue());


            FarBGSpawn(StartFarBgCliffSpawnAmount * farBGDistance);
            StartFarBgCliffSpawnAmount++;
            PlayerXPosFarBGCliff = player.position.x;
        }
        if (player.position.x - PlayerXPosVeryFarBG >= veryFarBGDistance)
        {
            Destroy(VeryFarBGQueue.Dequeue());


            VeryFarBGSpawn(VeryFarBgSpawnAmount * veryFarBGDistance);
            VeryFarBgSpawnAmount++;
            PlayerXPosVeryFarBG = player.position.x;
        }
    }

    public void NearObjSpawn(Vector3 pos)
    {
        
        

        GameObject near = Instantiate(nearObj[Random.Range(0, nearObj.Length)], transform.GetChild(0));

        
        near.transform.localPosition = pos;
        
        NearObjsQueue.Enqueue(near);
    }
    public void NearGrassSpawn(float xDistance)
    {
        GameObject nearGrass = Instantiate(nearBgGrass[Random.Range(0, nearBgGrass.Length)], transform.GetChild(1));
        nearGrass.transform.localPosition = new Vector3(xDistance,0,0) + nearGrassDepth;
        nearBgGrassQueue.Enqueue(nearGrass);
    }
    public void NearVineSpawn(float xDistance)
    {
        GameObject nearVine = Instantiate(nearVines[Random.Range(0, nearVines.Length)], transform.GetChild(2));
        nearVine.transform.localPosition = new Vector3(xDistance, 0, 0) + nearVineDepth;
        NearVineQueue.Enqueue(nearVine);
    }
    public void NearTreeSpawn(float xDistance)
    {
        GameObject nearTree = Instantiate(nearBgTrees[Random.Range(0, nearBgTrees.Length)], transform.GetChild(3));
        nearTree.transform.localPosition = new Vector3(xDistance, 0, 0) + nearTreeDepth;
        NearBgTreeQueue.Enqueue(nearTree);
    }
    public void MidVineSpawn(float xDistance)
    {
        GameObject midVine = Instantiate(midVines[Random.Range(0, midVines.Length)], transform.GetChild(4));
        midVine.transform.localPosition = new Vector3(xDistance, 0, 0) + midVineDepth;
        MidVineQueue.Enqueue(midVine);
    }
    public void MidGrassSawn(float xDistance)
    {
        GameObject midGrass = Instantiate(midBgGrass[Random.Range(0, midBgGrass.Length)], transform.GetChild(5));
        midGrass.transform.localPosition = new Vector3(xDistance, 0, 0) + midGrassDepth;
        MidBgGrassQueue.Enqueue(midGrass);
    }
    public void FarGrassSpawn(float xDistance)
    {
        GameObject farGrass = Instantiate(farBgGrass[Random.Range(0, farBgGrass.Length)], transform.GetChild(6));
        farGrass.transform.localPosition = new Vector3(xDistance, 0, 0) + farGrassDepth;
        FarBgGrassQueue.Enqueue(farGrass);
    }
    public void MidTreeSpawn(float xDistance)
    {
        GameObject midTree = Instantiate(midBgTrees[Random.Range(0, midBgTrees.Length)], transform.GetChild(7));
        midTree.transform.localPosition = new Vector3(xDistance, 0, 0) + midTreeDepth;
        MidBgTreeQueue.Enqueue(midTree);
    }
    public void FarVineSpawn(float xDistance)
    {
        GameObject farVine = Instantiate(farVines[Random.Range(0, farVines.Length)], transform.GetChild(8));
        farVine.transform.localPosition = new Vector3(xDistance, 0, 0) + farVineDepth;
        FarVineQueue.Enqueue(farVine);
    }
    public void FarTreeSpawn(float xDistance)
    {
        GameObject farTree = Instantiate(farBgTree[Random.Range(0, farBgTree.Length)], transform.GetChild(9));
        farTree.transform.localPosition = new Vector3(xDistance, 0, 0) + farTreeDepth;
        FarBgTreeQueue.Enqueue(farTree);
    }
    public void FarBGSpawn(float xDistance)
    {
        BGSpawned = BGSpawned == 0 ? 1 : 0;
        int realBg;
        if (Random.Range(0, 100) > 5)
            realBg = BGSpawned;
        else
            realBg = 2;
        GameObject farBG = Instantiate(farBGs[realBg], transform.GetChild(10));
        farBG.transform.localPosition = new Vector3(xDistance, 0, 0) + farBGDepth;
        if (realBg == 2)
            farBG.transform.localPosition += new Vector3(0, 2.1f, 0);
        FarBGsQueue.Enqueue(farBG);
    }
    public void VeryFarBGSpawn(float xDistance)
    {
        GameObject veryfarBG = Instantiate(veryFarBG, transform.GetChild(11));
        veryfarBG.transform.localPosition = new Vector3(xDistance, 0, 0) + veryFarBGDepth;
        VeryFarBGQueue.Enqueue(veryfarBG);
    }
}
