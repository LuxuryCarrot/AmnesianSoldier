using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : EnemyBattleParent
{
    public float temp;
    public int Amount;
    public float damage;
    public override void Execute()
    {
        base.Execute();


        PlayerManager.playerSingleton.gameObject.AddComponent<Dotdamage>();
        PlayerManager.playerSingleton.gameObject.GetComponent<Dotdamage>().DotDamageInst(temp, Amount, damage);
    }
}
