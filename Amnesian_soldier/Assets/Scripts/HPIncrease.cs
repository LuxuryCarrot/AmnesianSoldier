using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPIncrease : MonoBehaviour
{
    public void HPChange()
    {
        int playerhp = (int)PlayerManager.playerSingleton.HP;
        for(int j=0; j<PlayerManager.playerSingleton.HPMAX; j++)
        {
            if (j < playerhp)
                transform.GetChild(j).gameObject.SetActive(true);
            else
                transform.GetChild(j).gameObject.SetActive(false);
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
        for (int j = 0; j < i; j++)
        {
            GameObject hpnew = Instantiate(
                Resources.Load("Prefabs/UIPrefab/HPEmptyImage") as GameObject, transform.parent.GetChild(0));
            hpnew.transform.position = new Vector3(-579.4f + i * 60, 473.7f, 0);
        }
        PlayerManager.playerSingleton.HPMAX += i;
    }
}
