using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//입력이 없을 시 적을 회피하는 코드
public class PlayerAbandon : PlayerParent
{
    public float zSpeed;
    bool getBack;
    float temp;

    public override void BeginState()
    {
        base.BeginState();
        //상태 시작시 속도를 초기화함
        zSpeed = Random.Range(0,1)>=0.5? 20: -20;
        getBack = false;
        temp = 0.1f;
        
        manager.iteratingEnemy = null;
    }
    private void Update()
    {
        //적에게 z축 방향으로 피하는 코드
        if(!getBack)
        {
            manager.controller.Move(new Vector3(0, 0, zSpeed * Time.deltaTime) + manager.speed*Time.deltaTime);
            if (1-Mathf.Abs(transform.position.z) <= 0.1f)
                getBack = true;
        }
        else if(temp>=0)
        {
            //높이가 일정값 이상 올라가면 원래대로 감.
            manager.controller.Move(manager.speed*Time.deltaTime);
            temp -= Time.deltaTime;
        }
        else
        {
            //다시 원래 z 축으로 돌아감.
            manager.controller.Move(new Vector3(0, 0, -zSpeed * Time.deltaTime) + manager.speed * Time.deltaTime);
            if (Mathf.Abs(transform.position.z) <= 0.2f)
            {
                manager.transform.position = new Vector3(manager.transform.position.x, manager.transform.position.y, 0);
                manager.losed = false;
                manager.SetState(PlayerState.IDLE);
            }
        }
    }
    public override void EndState()
    {
        base.EndState();
        
    }
}
