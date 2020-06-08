using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어의 넉백.
public class PlayerKnockBack : PlayerParent
{
    public override void BeginState()
    {
        base.BeginState();
        manager.ySpeed = -3.0f;
        
        manager.GetComponent<CharacterController>().Move(new Vector3(2 * Time.deltaTime, -manager.ySpeed * Time.deltaTime, 0));
    }
    private void Update()
    {
        manager.controller.Move(-manager.speed * Time.deltaTime);
       

        if (manager.ySpeed >=2.9f)
            manager.SetState(PlayerState.IDLE);
    }
    public override void EndState()
    {
        base.EndState();
    }
}
