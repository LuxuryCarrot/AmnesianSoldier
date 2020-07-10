using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dotdamage : MonoBehaviour
{
    public float tickRate;
    public int tickAmount;
    public float damage;
    float DamageStacked;

    private void Update()
    {
        float temp = 0;

        if (tickRate == 0)
            return;

        
            temp += Time.deltaTime;
            if(temp >= tickRate)
            {
                temp = 0;
                tickAmount--;
                GetComponent<PlayerManager>().HP -= damage;
            DamageStacked += damage;
            }

        if(DamageStacked>=1)
        {
            StageManager.stageSingletom.HPText.GetComponent<HPIncrease>().HPChange();
            DamageStacked --;
        }
        if (tickAmount <= 0)
            Destroy(this);
        
    }
    public void DotDamageInst(float rate, int am, float dam)
    {
        tickRate = rate;
        tickAmount = am;
        damage = dam;
    }
}
