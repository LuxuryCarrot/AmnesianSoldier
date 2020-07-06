using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public PlayerManager manager;
    
    public float weaponDamage;
    public float weaponRange;

    private void Awake()
    {
        manager = GetComponent<PlayerManager>();
    }

    public virtual void Execute() { }
}
