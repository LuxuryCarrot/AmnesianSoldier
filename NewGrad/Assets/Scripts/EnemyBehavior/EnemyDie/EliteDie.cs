using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteDie : EnemyDieParent
{
    public float xSpeed;
    public float xAccel;
    public override void Begin()
    {
        base.Begin();
        xSpeed = 20.0f;
        xAccel = 25.0f;
        manager.anim.SetBool("Die", true);
    }
    public override void Execute()
    {
        
        if (xSpeed <= 0)
            return;
        transform.position += new Vector3(xSpeed, 0, 0) * Time.deltaTime;
        xSpeed -= xAccel * Time.deltaTime;
        
    }
    
}
