using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrapAttack : BossParent
{
    float trapTemp;
    int traCount;
    public override void BeginState()
    {
        base.BeginState();
        trapTemp = 3.0f;
        traCount = 2;
    }
    private void Update()
    {
        trapTemp -= Time.deltaTime;
        if (traCount == 0)
            manager.SetState(BossState.IDLE);

        if(trapTemp<=0)
        {
            
            for(int i=0; i<3; i++)
            {
                Ray ray = new Ray(transform.position + new Vector3(i, 0,0)
                    , new Vector3(0, -10, 0));
                RaycastHit hitObj;
                if(Physics.Raycast(ray, out hitObj, 1024))
                {
                    
                    hitObj.transform.gameObject.GetComponent<FallingMapBox>().CrashBlock();
                }
            }
            GameObject newTrap = Instantiate(
                Resources.Load("Prefabs/KaizoTrap/FallingTrap") as GameObject);
            newTrap.transform.position = new Vector3(transform.position.x, 0, 0);

            trapTemp = 2.0f;
            traCount--;
        }
        if (traCount < 0)
            manager.SetState(BossState.IDLE);
    }
    public override void EndState()
    {
        base.EndState();
    }
}
