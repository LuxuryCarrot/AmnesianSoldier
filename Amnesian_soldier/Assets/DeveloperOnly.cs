using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperOnly : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            if (StageManager.stageSingletom.current != StageState.BOSSBATTLE)
            {
                StageManager.stageSingletom.SetState(StageState.MAPSELECT);
                PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
                PlayerManager.playerSingleton.transform.position = new Vector3(MapPositionManager.mapMax, 2, 0);
                MapPositionManager.mapPos = MapPositionManager.mapMax;
            }
            else
                PlayerManager.playerSingleton.boss.SetState(BossState.DIE);
        }
    }
}
