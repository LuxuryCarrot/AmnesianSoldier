using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : ButtonParent
{
    public override void Execute()
    {
        base.Execute();
        Time.timeScale = 1;
        StageManager.stageSingletom.OutGameToolsCanvas.SetActive(false);
    }
}
