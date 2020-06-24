using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPIncrease : MonoBehaviour
{
    public void HPChange(int i)
    {
        if(i>0)
        {
            for(int j=0; j<5 && i!=0; j++)
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
            for (int j = 0; j < 5 && i != 0; j++)
            {
                if (transform.GetChild(4-j).gameObject.activeInHierarchy)
                {
                    transform.GetChild(4-j).gameObject.SetActive(false);
                    i++;
                }
            }
        }
    }
}
