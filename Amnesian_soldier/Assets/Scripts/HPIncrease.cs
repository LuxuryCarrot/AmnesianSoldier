using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPIncrease : MonoBehaviour
{
    public void HPChange(int i)
    {
        if(i>0)
        {
            for(int j=0; j<transform.childCount && i!=0; j++)
            {
                if (!transform.GetChild(j).gameObject.activeInHierarchy)
                {
                    transform.GetChild(j).gameObject.SetActive(true);
                    i--;
                }
            }
        }
        else
        {
            for (int j = 0; j < transform.childCount && i != 0; j++)
            {
                if (transform.GetChild(4-j).gameObject.activeInHierarchy)
                {
                    transform.GetChild(4-j).gameObject.SetActive(false);
                    i++;
                }
            }
        }
    }
    public void HPMAXIncrease(int i)
    {
        for(int j=0; j<i; j++)
        {
            GameObject hpnew = Instantiate(
                Resources.Load("Prefabs/UIPrefab/HPImage") as GameObject, transform);
            hpnew.transform.position = new Vector3(-579.4f+i*60, 473.7f, 0);
        }
        PlayerManager.playerSingleton.HPMAX += i;
    }
}
