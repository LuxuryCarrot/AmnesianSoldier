using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : WeaponParent
{
    public int bulletCanUse;
    public int bulletMax;
    public int bulletCanReload;

    public float bulletDamage;

    
    private void Start()
    {
        bulletCanReload = 5;
        bulletMax = 15;

        bulletCanUse = bulletCanReload;
        bulletMax -= bulletCanReload;
        weaponDamage = 1;
        bulletDamage = 2;
        StageManager.stageSingletom.BulletCanvas.SetActive(true);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && bulletMax>0)
        {
            manager.anim.SetTrigger("Reload");
            for(;bulletCanUse<bulletCanReload ; )
            {
                bulletMax--;
                bulletCanUse++;
            }
            manager.anim.SetBool("BulletEmpty", false);
        }

        if (bulletCanUse <= 0)
            manager.anim.SetBool("BulletEmpty", true);
    }

    public override void Execute()
    {
        base.Execute();
        
        manager.anim.SetBool("Success", true);
        manager.anim.SetBool("Guarding", false);
        manager.anim.SetBool("Charging", false);
        if (bulletCanUse <= 0)
            manager.attackType = AttackType.HORIZON;
    }
}
