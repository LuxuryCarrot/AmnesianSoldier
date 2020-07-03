using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public float time;

    public void InitializeTime()
    {
        time = 15;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        StageManager.stageSingletom.StoreCanvas.transform.GetChild(1).GetComponent<Text>().text = ((int)time).ToString();

        if(time <=0)
        {
            time = 15;
            StageManager.stageSingletom.SetState(StageState.MAPSELECT);
            StageManager.stageSingletom.StoreCanvas.SetActive(false);
            
        }
    }
}
