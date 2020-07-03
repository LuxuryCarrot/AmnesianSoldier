using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParent : MonoBehaviour
{
    public BossManager manager;
    private void Awake()
    {
        manager = GetComponent<BossManager>();
    }
    public virtual void BeginState()
    {

    }
    public virtual void EndState() { }
}
