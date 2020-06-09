using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieParent : MonoBehaviour
{
    public EnemyManager manager;
    private void Awake()
    {
        manager = GetComponent<EnemyManager>();
    }
    public virtual void Execute()
    {

    }
}
