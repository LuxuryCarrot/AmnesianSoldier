using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGetEnemy : MonoBehaviour
{
    public void Die()
    {
        Destroy(transform.parent.gameObject);
    }
}
