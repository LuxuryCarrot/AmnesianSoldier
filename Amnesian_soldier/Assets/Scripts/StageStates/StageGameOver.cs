using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 오버 상태.
public class StageGameOver : StageParent
{
    public GameObject GameoverCanvas;
    

    private void Awake()
    {
        GameoverCanvas.SetActive(false);
    }
    public override void BeginState()
    {
        base.BeginState();
        GameoverCanvas.SetActive(true);
        
    }
    private void Update()
    {
        
    }
    public override void EndState()
    {
        base.EndState();
    }
}
