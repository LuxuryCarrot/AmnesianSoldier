using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//넉백 상태
public class EnemyKnockBack : EnemyParent
{
    public float yspeed;
    public float gravity=10.0f;
    public override void BeginState()
    {
        base.BeginState();
        manager.ySpeed = -3.0f;
        manager.GetComponent<CharacterController>().Move(new Vector3(2 * Time.deltaTime, -manager.ySpeed * Time.deltaTime, 0));
    }
    private void Update()
    {
        yspeed += gravity * Time.deltaTime;
        manager.GetComponent<CharacterController>().Move(new Vector3(2 * Time.deltaTime, 0, 0));
        
        if(yspeed>=7.0f)
        {
            manager.SetState(EnemyState.IDLE);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
