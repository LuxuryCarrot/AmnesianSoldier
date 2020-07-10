using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedParent : MonoBehaviour
{
    public virtual void Execute() { }
    public EnemyManager manager;
    private void Awake()
    {
        manager = GetComponent<EnemyManager>();
    }
}
