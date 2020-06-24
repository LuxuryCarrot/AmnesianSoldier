using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//맵 스포너를 상속받은 1_1 스포너
public class MapSpawnInstance : MapSpawnerParent
{
    public GameObject mapPrefab;
    public GameObject[] monsterPrefab;
    public GameObject[] eliteMosterPrefab;
    public int startSpawnPos;
    public int mapMaxPos;
    public int monsterMinDistance;
    public int monsterMaxDistance;
    int monsterMinDistanceTemp=0;
    public int mapDontCamChase;
    public bool isEliteStage;
    int maxElite;

    //1스테이지 스폰 패턴.
    private void Awake()
    {
        if (isEliteStage)
            maxElite = 4;
        else
            maxElite = 2;
        MonsterManager.Monsters.Clear();
        MapPositionManager.mapPos += startSpawnPos;
        for(int i=0; i< startSpawnPos; i++)
        {
           
            GameObject mapBox = Instantiate(mapPrefab, this.transform);
            //최소 거리 이상이 되면 확률에 따라 몹 스폰.
            mapBox.transform.localPosition = new Vector3(MapPositionManager.mapMax+i, 0, 0);
            if (i <= startSpawnPos - mapDontCamChase)
            {
                if (i >= 10 && Random.Range(0, 20) <= 1 && monsterMinDistanceTemp >= monsterMinDistance)
                {
                    GameObject monster;

                    if (Random.Range(0, 0.1f) >= 0.05f && maxElite > 0)
                    {
                        maxElite--;
                        monster = Instantiate(eliteMosterPrefab[Random.Range(0, eliteMosterPrefab.Length-1)], new Vector3(MapPositionManager.mapMax + i, 1.5f, 0), Quaternion.identity, this.transform);
                    }
                    else
                        monster = Instantiate(monsterPrefab[Random.Range(0, monsterPrefab.Length)], new Vector3(MapPositionManager.mapMax + i, 1.5f, 0), Quaternion.identity, this.transform);
                    //monster.transform.localPosition = new Vector3(MapPositionManager.mapMax + i, 1.5f, 0);
                    monsterMinDistanceTemp = 0;
                    MonsterManager.Monsters.Add(monster);
                }

                monsterMinDistanceTemp++;
                //최대 거리 이상 되면 몬스터 무조건 스폰.
                if (monsterMinDistanceTemp >= monsterMaxDistance)
                {
                    GameObject monster;

                    if (Random.Range(0, 0.1f) >= 0.05f && maxElite > 0)
                    {
                        maxElite--;
                        monster = Instantiate(eliteMosterPrefab[Random.Range(0, eliteMosterPrefab.Length-1)], new Vector3(MapPositionManager.mapMax + i, 1.5f, 0), Quaternion.identity, this.transform);
                    }
                    else
                        monster = Instantiate(monsterPrefab[Random.Range(0, monsterPrefab.Length)], new Vector3(MapPositionManager.mapMax + i, 1.5f, 0), Quaternion.identity, this.transform);
                    //monster.transform.localPosition = new Vector3(MapPositionManager.mapMax + i, 1.5f, 0);
                    monsterMinDistanceTemp = 0;
                    MonsterManager.Monsters.Add(monster);
                }
            }
        }
        MapPositionManager.mapDontCmaChase = mapDontCamChase;
        MapPositionManager.mapMax += mapMaxPos;
        MapPositionManager.mapMaxCurrent = mapMaxPos;
    }
    public override void MapSpawn()
    {
        if (MapPositionManager.mapPos == MapPositionManager.mapMax)
            return;
        GameObject mapBox = Instantiate(mapPrefab, this.transform);
        //최소 거리 이상이 되면 확률에 따라 몹 스폰.
        if (MapPositionManager.mapPos <= MapPositionManager.mapMax - mapDontCamChase)
        {
            if (Random.Range(0, 20) <= 1 && monsterMinDistanceTemp >= monsterMinDistance)
            {
                GameObject monster = Instantiate(monsterPrefab[Random.Range(0, monsterPrefab.Length)], new Vector3(MapPositionManager.mapPos, 1.5f, 0), Quaternion.identity, this.transform);
                //monster.transform.localPosition = new Vector3(MapPositionManager.mapPos, 1.5f, 0);
                monsterMinDistanceTemp = 0;
                MonsterManager.Monsters.Add(monster);
            }

            monsterMinDistanceTemp++;
            //최대 거리 이상 되면 몬스터 무조건 스폰.
            if (monsterMinDistanceTemp >= monsterMaxDistance)
            {
                GameObject monster = Instantiate(monsterPrefab[Random.Range(0, monsterPrefab.Length)], new Vector3(MapPositionManager.mapPos, 1.5f, 0), Quaternion.identity, this.transform);
                //monster.transform.localPosition = new Vector3(MapPositionManager.mapPos, 1.5f, 0);
                monsterMinDistanceTemp = 0;
                MonsterManager.Monsters.Add(monster);
            }
        }
        mapBox.transform.localPosition = new Vector3(MapPositionManager.mapPos, 0, 0);
        MapPositionManager.mapPos++;
    }
}
