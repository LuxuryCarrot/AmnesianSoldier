using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : WeaponParent
{
    public override void Execute()
    {
        base.Execute();
        
        manager.anim.SetBool("Success", true);
        manager.anim.SetBool("Charging", false);
        manager.attackType = AttackType.HORIZON;
    }
}
