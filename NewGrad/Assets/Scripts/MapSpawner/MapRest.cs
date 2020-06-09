using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRest : MapSpawnerParent
{
    public GameObject mapPrefab;
    public int startSpawnPos=20;

    private void Awake()
    {
        //StageManager.stageSingletom.SetState(StageState.REST);
        PlayerManager.playerSingleton.HP = 3;
        StageManager.stageSingletom.HPText.text = "3";
        for (int i = 0; i < startSpawnPos; i++)
        {

            GameObject mapBox = Instantiate(mapPrefab, this.transform);
            
            mapBox.transform.localPosition = new Vector3(MapPositionManager.mapMax-10 + i, 0, 0);
            
        }
    }
    private void Update()
    {
        
    }
}
