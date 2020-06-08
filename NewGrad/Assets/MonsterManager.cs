using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//몬스터 들을 일괄 관리하는 매니저. 이 안에는 몬스터의 리스트가 있음.
public class MonsterManager : MonoBehaviour
{
    public static List<GameObject> Monsters = new List<GameObject>();

    private void Awake()
    {
        Monsters.Clear();
    }
}
