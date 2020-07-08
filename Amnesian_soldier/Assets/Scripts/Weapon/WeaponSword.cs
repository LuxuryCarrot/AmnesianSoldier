using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : WeaponParent
{
    private void Start()
    {
        weaponDamage = 1;
    }
    public override void Execute()
    {
        base.Execute();
        manager.anim.SetBool("Success", true);
        manager.anim.SetBool("Guarding", false);
        manager.anim.SetBool("Charging", false);
        manager.attackType = AttackType.HORIZON;
    }
}
