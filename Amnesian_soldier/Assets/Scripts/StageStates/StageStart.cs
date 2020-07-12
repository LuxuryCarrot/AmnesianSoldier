using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 시작시 카운트다운을 세는 상태
public class StageStart : StageParent
{
    public float temp;

    public override void BeginState()
    {
        base.BeginState();
        //게임 시작시 카운트 다운을 초기화 한다.
        temp = 0.0f;
        //manager.BlueAttackCurrent = manager.BlueAttackAmount;
        //manager.RedAttackCurrent = manager.RedAttackAmount;
    }
    private void Update()
    {
        temp -= Time.deltaTime;
        if(temp <=0)
        {
            //카운트 다운이 끝날 시 스테이지의 상태를 idle 로 바꾼다.
            
            temp = 3.0f;
        }
    }
    public override void EndState()
    {
        base.EndState();
    }

}
