using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어의 넉백.
public class PlayerKnockBack : PlayerParent
{
    public Vector3 backSpeed;
    float knockBackTime;

    public override void BeginState()
    {
        base.BeginState();
        backSpeed = new Vector3(10, 0, 0);
        Camera.main.transform.position += new Vector3(2, 0, 0);
        manager.ySpeed = -2.5f;
        
        manager.GetComponent<CharacterController>().Move(new Vector3(0, -manager.ySpeed * Time.deltaTime, 0));
    }
    private void Update()
    {
        
        manager.controller.Move(-backSpeed * Time.deltaTime*1.5f);
        Camera.main.transform.position = BattleDetermine.Vector3Slerp(Camera.main.transform.position,
                                                                           transform.position + manager.camPos, 5.0f*Time.deltaTime);

        if (manager.ySpeed >= 2.0f)
        {
            Camera.main.transform.position = transform.position + manager.camPos;
            manager.SetState(PlayerState.IDLE);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
