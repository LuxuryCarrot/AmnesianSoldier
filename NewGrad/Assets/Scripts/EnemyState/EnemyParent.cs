using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyParent : MonoBehaviour
{

    //몬스터의 상태를 정의하는 부모클래스
    public EnemyManager manager;
    private void Awake()
    {
        manager = GetComponent<EnemyManager>();
    }
    public virtual void BeginState()
    {

    }
    public virtual void EndState()
    {

    }
}
