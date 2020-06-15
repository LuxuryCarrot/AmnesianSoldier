using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCardDestroyer : MonoBehaviour
{
    public bool isParented;
    float temp = 3.0f;

    // Update is called once per frame
    void Update()
    {
        if (isParented && PlayerManager.playerSingleton.iteratingEnemy == null)
        {
            temp -= Time.deltaTime;
            if (temp <= 0)
            {
                PlayerManager.playerSingleton.attackType.Clear();
                for (int i = 0; i < PlayerManager.playerSingleton.inputSlot.transform.childCount; i++)
                    PlayerManager.playerSingleton.inputSlot.transform.GetChild(i).GetComponent<CardParent>().DestroyThis();

            }
        }
    }
}
