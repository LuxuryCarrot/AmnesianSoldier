using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerParent
{
    float grav;
    float ySpeed;
    float yPos;
    public override void BeginState()
    {
        base.BeginState();
        ySpeed = 23;
        grav = 80;
        yPos = Camera.main.transform.position.y;
        manager.anim.SetTrigger("Jump");
    }
    private void Update()
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, yPos, Camera.main.transform.position.z);
        manager.controller.Move(manager.speedIncrease * manager.speed * Time.deltaTime
                                + new Vector3(0, ySpeed,0)*Time.deltaTime);
        ySpeed -= grav * Time.deltaTime;

        if (ySpeed <= -23)
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
