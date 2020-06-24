using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGetEnemy : MonoBehaviour
{
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
}
