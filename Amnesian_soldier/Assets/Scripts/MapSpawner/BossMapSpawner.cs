using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMapSpawner : MapSpawnerParent
{
    public GameObject mapPrefab;
    public int startSpawnPos;

    private void Awake()
    {
        
         for(int i=-10; i<startSpawnPos; i++)
         {
            GameObject mapBox = Instantiate(mapPrefab, this.transform);
            
            mapBox.transform.localPosition = new Vector3(MapPositionManager.mapMax + i, 0, 0);
         }
        MapPositionManager.mapMax += startSpawnPos;
    }

    public override void MapSpawn()
    {
        GameObject mapBox = Instantiate(mapPrefab, this.transform);
        
        mapBox.transform.localPosition = new Vector3(MapPositionManager.mapMax, 0, 0);
        MapPositionManager.mapMax++;
    }
}
