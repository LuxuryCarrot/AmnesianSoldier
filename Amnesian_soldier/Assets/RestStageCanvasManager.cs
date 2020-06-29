using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestStageCanvasManager : MonoBehaviour
{
    public void MapButtonOn()
    {
        
            if (StageManager.stageSingletom.mapCanvas.activeInHierarchy)
            {
                StageManager.stageSingletom.mapCanvas.transform.GetChild(0).localPosition = new Vector3(0, 1190, 0);
                StageManager.stageSingletom.mapCanvas.SetActive(false);

                //manager.mapSelectCanvas.SetActive(false);
            }
            else
            {
                StageManager.stageSingletom.mapCanvas.SetActive(true);
                StageManager.stageSingletom.mapCanvas.transform.GetChild(0).localPosition = Vector3.zero;
                //manager.mapCanvas.SetActive(true);
            }
        
    }
    public void SkipMapButton()
    {
        StageManager.stageSingletom.GetComponent<StageRest>().temp = 0;
    }
}
