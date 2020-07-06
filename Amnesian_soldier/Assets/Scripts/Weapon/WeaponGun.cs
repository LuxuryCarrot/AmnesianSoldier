using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : WeaponParent
{
    public int bulletCanUse;
    public int bulletMax;
    public int bulletCanReload;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            
        }
    }
}
