using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestStageSelect : MonoBehaviour
{
    public void HPReset()
    {
        PlayerManager.playerSingleton.HP = 5;
        StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange(5);
        StageManager.stageSingletom.GetComponent<StageRest>().RestTypeSelected();
    }
    public void SpeedReset()
    {
        PlayerManager.playerSingleton.speed = new Vector3(12, 0, 0);
        StageManager.stageSingletom.GetComponent<StageRest>().RestTypeSelected();
    }
}
