﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStore : MapSpawnerParent
{
    public GameObject mapPrefab;
    public int startSpawnPos = 20;

    private void Awake()
    {
        //StageManager.stageSingletom.SetState(StageState.REST);
        //PlayerManager.playerSingleton.HP = 5;
        //StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange(4);
        PlayerManager.playerSingleton.timeScale = 1;
        Time.timeScale = PlayerManager.playerSingleton.timeScale;
        for (int i = 0; i < startSpawnPos; i++)
        {

            GameObject mapBox = Instantiate(mapPrefab, this.transform);

            mapBox.transform.localPosition = new Vector3(MapPositionManager.mapMax - 10 + i, 0, 0);

        }
        GameObject merchant = Instantiate(Resources.Load("Prefabs/MapObjs/Merchant") as GameObject, this.transform);
        merchant.transform.position = PlayerManager.playerSingleton.transform.position + new Vector3(7, 0, 0); 
    }
    private void Update()
    {

    }
}
