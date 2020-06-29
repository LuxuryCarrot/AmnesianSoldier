using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAwake : EnemyAwakeParent
{
    bool isOnGround=false;
    float temp;
    private void Start()
    {
        GetComponent<CharacterController>().Move(new Vector3(2.5f, 3, 0));
        manager.range += 3;
        manager.gravity = 0;
        temp = 1.0f;
    }
    public override void Execute()
    {
        base.Execute();
        isOnGround = true;
    }
    private void Update()
    {
        if(isOnGround)
        {
            if (temp >= 0)
            {
                temp -= Time.deltaTime;
                GetComponent<CharacterController>().Move(PlayerManager.playerSingleton.speed * PlayerManager.playerSingleton.speedIncrease * Time.deltaTime);
            }
            else if (temp < 0)
            {
                manager.gravity = 20;
                GetComponent<CharacterController>().Move(new Vector3(-3, 0, 0) * Time.deltaTime);
                if (GetComponent<CharacterController>().isGrounded)
                {
                    manager.gravity = 10;
                    isOnGround = false;
                }
            }
        }
    }
}
