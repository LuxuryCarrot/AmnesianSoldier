using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawnManager : MonoBehaviour
{
    public GameObject nearObj;
    public GameObject farobj;
    public static Queue<GameObject> NearObjsQueue = new Queue<GameObject>();
    public static Queue<GameObject> FarObjsQueue = new Queue<GameObject>();
    public static Queue<GameObject> MidObjsQueue = new Queue<GameObject>();
    public int StartNearSpawnAmount;
    public int StartFarSawnAmount;
    public int startMidSpawnAmount;
    public GameObject midObj;
    int PlayerXPos;
    int PlayerFarXPOS;
    int playerMidXPOS;

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
        for (int i = -1; i <= StartNearSpawnAmount; i++)
            NearObjSpawn(new Vector3((i - 1) * 20, 0.5f, 0.5f));

        for (int i = 0; i <= StartFarSawnAmount; i++)
            farObjSpawn(new Vector3(i * 114, 0, 52));

        for (int i=-1; i<=startMidSpawnAmount; i++)
        {
            MidObjSpawn(new Vector3((i * 28.5f), 1.8f, 5.0f));
        }
    }
    private void FixedUpdate()
    {
        if (PlayerManager.playerSingleton.transform.position.x - PlayerXPos >= 20)
        {
            Destroy(NearObjsQueue.Dequeue());
            StartNearSpawnAmount++;

            NearObjSpawn(new Vector3((StartNearSpawnAmount - 1) * 20, 0.5f, 0.5f));
            PlayerXPos = (int)PlayerManager.playerSingleton.transform.position.x;
        }
        if (PlayerManager.playerSingleton.transform.position.x - PlayerFarXPOS >= 114)
        {
            Destroy(FarObjsQueue.Dequeue());
            StartFarSawnAmount++;
            farObjSpawn(new Vector3((StartFarSawnAmount - 1) * 114, 0, 52));
            PlayerFarXPOS = (int)PlayerManager.playerSingleton.transform.position.x;
        }
        if (PlayerManager.playerSingleton.transform.position.x - playerMidXPOS >= 28.5f)
        {
            Destroy(MidObjsQueue.Dequeue());
            startMidSpawnAmount++;
            MidObjSpawn(new Vector3((startMidSpawnAmount - 1) * 28.5f, 1.8f, 5.0f));
            playerMidXPOS = (int)PlayerManager.playerSingleton.transform.position.x;
        }
    }

    public void NearObjSpawn(Vector3 pos)
    {
        GameObject near = Instantiate(nearObj, transform.GetChild(0));
        near.transform.localPosition = pos;
        NearObjsQueue.Enqueue(near);
    }
    public void farObjSpawn(Vector3 pos)
    {
        GameObject far = Instantiate(farobj, transform.GetChild(1));
        far.transform.localPosition = pos;
        FarObjsQueue.Enqueue(far);
    }
    public void MidObjSpawn(Vector3 pos)
    {
        GameObject mid = Instantiate(midObj, transform.GetChild(2));
        mid.transform.localPosition = pos;
        MidObjsQueue.Enqueue(mid);
    }
}
