using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//떨어지는 타일 코드
public class FallingMapBox : MonoBehaviour
{

    float temp = 1.0f;
    public float gravity;
    float ySpeed = 0;
    bool isPlayerUp=false;
    bool startFall = false;

    private void Update()
    {
        //플레이어가 한번이라도 밟았는지를 검색
        if (-PlayerManager.playerSingleton.transform.position.x + transform.position.x <= 0.5f)
            isPlayerUp = true;

        //플레이어가 기본 상태고, 일정 거리 이상 멀어지면 떨어지게 하는 코드
        if ((PlayerManager.playerSingleton.transform.position.x - transform.position.x) > 2
            && isPlayerUp && (StageManager.stageSingletom.current == StageState.IDLE) && !startFall)
            startFall = true;

        if(startFall)
        {
            temp -= Time.deltaTime;
        }
        else if(temp <0)
        {
            ySpeed += gravity * Time.deltaTime;
            transform.position -= new Vector3(0, ySpeed * Time.deltaTime, 0);
            //새로운 맵을 생성하고 이 타일을 삭제하는 코드
            if(transform.position.y <= -3.0f)
            {
                GetComponentInParent<MapSpawnerParent>().MapSpawn();
                Destroy(this.gameObject);
            }
        }
    }
    public void CrashBlock()
    {
        startFall = true;
    }

    
}
