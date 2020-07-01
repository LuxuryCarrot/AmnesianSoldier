using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerParent
{
    float grav;
    float ySpeed;

    public override void BeginState()
    {
        base.BeginState();
        ySpeed = 20;
        grav = 80;
        Debug.Log("Jump");
        manager.anim.SetTrigger("Jump");
    }
    private void Update()
    {
        manager.controller.Move(manager.speedIncrease * manager.speed * Time.deltaTime
                                + new Vector3(0, ySpeed,0)*Time.deltaTime);
        ySpeed -= grav * Time.deltaTime;

        if (ySpeed <= -20)
        {
            manager.SetState(PlayerState.IDLE);
            manager.trap = null;
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
