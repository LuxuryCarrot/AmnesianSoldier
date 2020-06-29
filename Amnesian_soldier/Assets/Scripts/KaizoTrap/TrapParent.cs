﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapParent : MonoBehaviour
{
    public float maxRange;
    public float minRange;
    public bool iterating = false;

    public virtual void DetactThis()
    {
        if(transform.position.x- PlayerManager.playerSingleton.transform.position.x<=maxRange &&
            transform.position.x - PlayerManager.playerSingleton.transform.position.x>=0
            && PlayerManager.playerSingleton.trap==null)
        {
            PlayerManager.playerSingleton.trap = this;
        }
        else if(transform.position.x - PlayerManager.playerSingleton.transform.position.x < 0
            && PlayerManager.playerSingleton.trap == this)
        {
            PlayerManager.playerSingleton.trap = this;
        }
    }
    public virtual void Execute()
    {
        
    }
    public virtual void SpaceIterat()
    {

    }
}
