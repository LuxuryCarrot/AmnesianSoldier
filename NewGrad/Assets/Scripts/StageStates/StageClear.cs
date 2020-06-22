using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//게임 클리어 상태. 다른 코드의 개입이 없도록 게임 클리어 상태를 독립
public class StageClear : StageParent
{
    public GameObject ClearCanvas;

    private void Awake()
    {
        ClearCanvas.SetActive(false);
    }
    public override void BeginState()
    {
        base.BeginState();
        ClearCanvas.SetActive(true);
        StageManager.stageSingletom = null;
        PlayerManager.playerSingleton.SetState(PlayerState.DELAY);
    }
    private void Update()
    {
        
    
    }
    public override void EndState()
    {
        base.EndState();
    }
}
