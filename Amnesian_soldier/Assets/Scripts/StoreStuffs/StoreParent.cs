using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreParent : MonoBehaviour
{
    public virtual void Execute()
    {
        StageManager.stageSingletom.SetState(StageState.MAPSELECT);
        StageManager.stageSingletom.StoreCanvas.SetActive(false);
        
    }
}
