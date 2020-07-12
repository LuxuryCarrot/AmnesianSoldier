using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMapSpawner : MapSpawnerParent
{
    public GameObject mapPrefab;
    public int startSpawnPos;
    public float bossSpawnTime;
    bool bossSpawned;
    public GameObject bossMob;

    private void Awake()
    {
        bossSpawnTime = 1;
         for (int i=-10; i<startSpawnPos; i++)
         {
            GameObject mapBox = Instantiate(mapPrefab, this.transform);
            
            mapBox.transform.localPosition = new Vector3(MapPositionManager.mapMax + i, 0, 0);
         }
        MapPositionManager.mapMax += startSpawnPos;
    }
    private void Update()
    {
        if (PlayerManager.playerSingleton.current == PlayerState.DELAY)
            return;

        if(!bossSpawned)
           bossSpawnTime -= Time.deltaTime;
        if(bossSpawnTime<=0)
        {
            bossSpawned = true;
            GameObject bossSpawn = Instantiate(bossMob);
            bossSpawn.transform.position = PlayerManager.playerSingleton.transform.position + new Vector3(10, 10.0f, 0);
            bossSpawnTime = 3;
        }
    }

    public override void MapSpawn()
    {
        GameObject mapBox = Instantiate(mapPrefab, this.transform);
        
        mapBox.transform.localPosition = new Vector3(MapPositionManager.mapMax, 0, 0);
        MapPositionManager.mapMax++;
    }
}
