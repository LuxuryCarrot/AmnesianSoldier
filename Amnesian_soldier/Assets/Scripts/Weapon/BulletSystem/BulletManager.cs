using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    PLAYER=0,
    ENEMY
}

public class BulletManager : MonoBehaviour
{
    public float gravity;
    public float startXSpeed;
    public float startYSpeed;
    public BulletType shotBy;
    public float maxRange;
    public float damage;

    float xSpeed;
    float ySpeed;
    public float startXPos;
    float temp;

    private void Start()
    {
        temp = 1;
    }
    private void Update()
    {
        if (xSpeed == 0)
            return;

        transform.parent.position +=
            new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;

        ySpeed -= gravity * Time.deltaTime;
        temp -= Time.deltaTime;

        float degree = Mathf.Atan2(ySpeed, Mathf.Abs(xSpeed))*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(degree, 90, 0);

        if(shotBy == BulletType.PLAYER)
        {
            if(PlayerManager.playerSingleton.boss!=null 
                && PlayerManager.playerSingleton.boss.current==BossState.STUN)
            {
                if (Vector3.SqrMagnitude(PlayerManager.playerSingleton.boss.transform.position -
                       transform.parent.position) <= 1.0f)
                {

                    PlayerManager.playerSingleton.boss.hp -= damage;
                    Destroy(transform.parent.gameObject);
                    
                }
            }
            else if(MonsterManager.Monsters.Count!=0)
            {
                foreach(GameObject mob in MonsterManager.Monsters)
                {
                    if(Vector3.SqrMagnitude(mob.transform.position -
                       transform.parent.position) <= 1.0f)
                    {
                        EnemyManager manager = mob.GetComponent<EnemyManager>();
                        if(PlayerManager.playerSingleton.current!=PlayerState.PINN)
                           manager.SetState(EnemyState.KNOCKBACK);
                        manager.hp -= damage;
                        Destroy(transform.parent.gameObject);
                        break;
                    }
                }
                
            }
            
            
        }
        else
        {
            if(Vector3.SqrMagnitude(PlayerManager.playerSingleton.transform.position-
                transform.parent.position) <=1.0f )
            {
                if(PlayerManager.playerSingleton.attackType!=AttackType.GUARD)
                {
                    PlayerManager.playerSingleton.HP--;
                    PlayerManager.playerSingleton.speed *= 0.95f;
                    PlayerManager.playerSingleton.anim.SetBool("Damaged", true);
                    
                 
                    StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange();
                    PlayerManager.playerSingleton.SetState(PlayerState.KNOCKBACK);
                }

                Destroy(transform.parent.gameObject);
            }
        }

        if(temp<=0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void SetInfomation(float xs, float ys, float grav, BulletType who, float maxR) 
    {
        gravity = grav;
        startXSpeed = xs;
        startYSpeed = ys;
        shotBy = who;
        maxRange = maxR;

        xSpeed = startXSpeed;
        ySpeed = startYSpeed;
    }

    
}
