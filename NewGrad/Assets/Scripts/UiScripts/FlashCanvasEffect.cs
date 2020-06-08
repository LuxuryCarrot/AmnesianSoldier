using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashCanvasEffect : MonoBehaviour
{
    public float flashTime;
    float temp;

    private void Awake()
    {
        temp = flashTime;
    }

    private void Update()
    {
        temp -= Time.deltaTime;

        if(temp <=0)
        {
            temp = flashTime;
            gameObject.SetActive(false);
        }
    }
}
