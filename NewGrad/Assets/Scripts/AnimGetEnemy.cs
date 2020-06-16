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
    
}
