using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGetEnemy : MonoBehaviour
{

    public GameObject handArrow;
    public GameObject ShootArrow;
    public void Die()
    {
        
        MonsterManager.Monsters.Remove(transform.parent.gameObject);
        Destroy(transform.parent.gameObject);
    }
    public void OnionAppear()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/Onion/Appear");
    }

    public void OnionAttack()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/Onion/Attack");
    }

    public void OnionDie()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/Onion/Die");
    }
    public void Bounce()
    {
        GetComponent<Animator>().SetBool("Defence", false);
    }

    public void GoblinArrowStart()
    {
        float shootTime = (transform.parent.transform.position.x - PlayerManager.playerSingleton.transform.position.x)/(PlayerManager.playerSingleton.speed.x + 12) ;
        float gravity = 10;
        GameObject arrow = Instantiate(ShootArrow);
        ShootArrow.transform.position = transform.parent.transform.position;
        arrow.GetComponentInChildren<BulletManager>().SetInfomation(-12, shootTime * 5, gravity, BulletType.ENEMY, shootTime * 12 + 10);
    }
}
