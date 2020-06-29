using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//넉백 상태
public class EnemyKnockBack : EnemyParent
{
    public float yspeed;
    public float gravity=5.0f;
    public float temp;
    public override void BeginState()
    {
        base.BeginState();
        temp = 0;
        manager.ySpeed = -2.5f;
        manager.anim.SetTrigger("Bounce");
        manager.GetComponent<CharacterController>().Move(new Vector3(2 * Time.deltaTime, -manager.ySpeed * Time.deltaTime, 0));
    }
    private void Update()
    {
        manager.ySpeed += gravity * Time.deltaTime;
        
        manager.GetComponent<CharacterController>().Move(new Vector3(24 * Time.deltaTime, -manager.ySpeed*Time.deltaTime, 0));
        
        if(manager.ySpeed >=0 && transform.position.y <= 1.7f)
        {
            manager.SetState(EnemyState.IDLE);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
