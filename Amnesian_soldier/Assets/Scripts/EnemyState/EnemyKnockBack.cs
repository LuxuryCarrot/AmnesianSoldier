using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//넉백 상태
public class EnemyKnockBack : EnemyParent
{
    public float yspeed;
    public float gravity=10.0f;
    public float temp;
    public override void BeginState()
    {
        base.BeginState();
        temp = 0;
        //manager.ySpeed = -3.0f;
        //manager.GetComponent<CharacterController>().Move(new Vector3(2 * Time.deltaTime, -manager.ySpeed * Time.deltaTime, 0));
    }
    private void Update()
    {
        temp += Time.deltaTime;
        //yspeed += gravity * Time.deltaTime;
        manager.GetComponent<CharacterController>().Move(new Vector3(30 * Time.deltaTime, 0, 0));
        
        if(temp>=0.4f)
        {
            manager.SetState(EnemyState.IDLE);
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
