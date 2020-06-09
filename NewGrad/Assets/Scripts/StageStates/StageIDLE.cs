using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//일반적인 스테이지. 
public class StageIDLE : StageParent
{
    public override void BeginState()
    {
        base.BeginState();
    }
    private void Update()
    {
        //플레이어가 맵의 끝에 도달하면 맵을 펼치는 코드.
        if(MapPositionManager.mapMax-PlayerManager.playerSingleton.transform.position.x<=1)
        {

            if (MapNode.EndNode != null)
            {
                manager.SetState(StageState.GAMECLEAR);

            }
            else
            {
                //Destroy(MapPositionManager.field.transform.GetChild(0).gameObject);
                manager.SetState(StageState.MAPSELECT);
            }
        }
    }
    public override void EndState()
    {
        base.EndState();
    }
}
