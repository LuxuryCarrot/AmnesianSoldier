using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawnManager : MonoBehaviour
{
    public GameObject[] nearObj;
    public GameObject farobj;
    public static Queue<GameObject> NearObjsQueue = new Queue<GameObject>();
    public static Queue<GameObject> FarObjsQueue = new Queue<GameObject>();
    public int StartNearSpawnAmount;
    public int StartFarSawnAmount;
    float PlayerXPos;
    float PlayerFarXPOS;

    private void Awake()
    {
        NearObjsQueue.Clear();
        FarObjsQueue.Clear();

    }
    private void Start()
    {
        PlayerXPos = PlayerManager.playerSingleton.transform.position.x+3;
        PlayerFarXPOS = PlayerManager.playerSingleton.transform.position.x;
        for (int i = 1; i <= StartNearSpawnAmount; i++)
            NearObjSpawn(new Vector3((i - 1)*3, 0.3f, 4));

        for (int i = 0; i <= StartFarSawnAmount; i++)
            farObjSpawn(new Vector3(i * 76, 4, 32));
    }
    private void Update()
    {
        if(PlayerManager.playerSingleton.transform.position.x-PlayerXPos>=3)
        {
            Destroy(NearObjsQueue.Dequeue());
            StartNearSpawnAmount++;
            NearObjSpawn(new Vector3((StartNearSpawnAmount - 1)*3, 0.3f, 4));
            PlayerXPos = PlayerManager.playerSingleton.transform.position.x;
        }
        if (PlayerManager.playerSingleton.transform.position.x - PlayerFarXPOS >= 76)
        {
            Destroy(FarObjsQueue.Dequeue());
            StartFarSawnAmount++;
            farObjSpawn(new Vector3((StartFarSawnAmount - 1) * 76, 4, 32));
            PlayerFarXPOS = PlayerManager.playerSingleton.transform.position.x;
        }
    }

    public void NearObjSpawn(Vector3 pos)
    {
        GameObject near = Instantiate(nearObj[Utilities.NewRandom(0, nearObj.Length-1)], transform.GetChild(0));
        near.transform.localPosition = pos;
        NearObjsQueue.Enqueue(near);
    }
    public void farObjSpawn(Vector3 pos)
    {
        GameObject far = Instantiate(farobj, transform.GetChild(1));
        far.transform.localPosition = pos;
        FarObjsQueue.Enqueue(far);
    }
}
